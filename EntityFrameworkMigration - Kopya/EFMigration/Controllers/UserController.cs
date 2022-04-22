using AutoMapper;
using EntityFrameworkMigration.DataAccess.Abstract;
using EntityFrameworkMigration.Entities;
using EntityFrameworkMigration.Entities.DTO;
using EntityFrameworkMigration.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserDao _userDao;
        private readonly ISchoolDao _schoolDao;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper,IUserDao userDao,ISchoolDao schoolDao)
        {
            _mapper = mapper;
            _schoolDao = schoolDao;
            _userDao = userDao;
        }
        
        [HttpGet]
        public IActionResult GetAllWithDetails()
        {
            var users = _userDao.GetUsersWithDetails();
            var userDetails = _mapper.Map<List<UserDetailViewModel>>(users);
            return Ok(userDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userDao.GetUsersWithDetails(x => x.Id == id);
            if (user == null)
            {
                return BadRequest("Böyle bir kullanıcı id si yok. işlem başarısız.");
            }
            var schoolDetail = _mapper.Map<UserDetailViewModel>(user[0]);
            return Ok(schoolDetail);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] AddUserViewModel user)
        {
            var result = _userDao.GetAll(x => (x.FirstName.ToLower() == user.FirstName.ToLower() && x.LastName == user.LastName));
            var school = _schoolDao.GetAll(x => x.Name.ToLower() == user.SchoolName.ToLower());
            if(result.Count != 0)
            {
                return BadRequest("Bu isim ve soyisimde bir kullanıcı var.İşlem başarısız.");
            }
            if(school.Count == 0)
            {
                return BadRequest("Böyle bir okul yok.Lütfen önce okulu kaydedin.İşlem Başarısız.");
            }

            User userToBeAdded = new User();
            userToBeAdded.FirstName = user.FirstName;
            userToBeAdded.LastName = user.LastName;
            userToBeAdded.Email = user.Email;
            userToBeAdded.PhoneNumber = user.PhoneNumber;
            userToBeAdded.SchoolId = school[0].Id;

            _userDao.Add(userToBeAdded);

            return Ok("İşlem başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDetail user)
        {
            var result = _userDao.GetById(x => x.Id == user.Id);
            var school = _schoolDao.GetAll(x => x.Name.ToLower() == user.SchoolName.ToLower());
            if (result == null)
            {
                return BadRequest("Böyle bir kullanıcı id si yok.İşlem başarısız.");
            }
            if(school.Count == 0)
            {
                return BadRequest("Böyle bir okul yok.Lütfen önce okulu kaydedin.İşlem başarısız.");
            }

            User userToBeUpdated = new User();
            userToBeUpdated.Id = user.Id;
            userToBeUpdated.FirstName = user.FirstName;
            userToBeUpdated.LastName = user.LastName;
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.PhoneNumber = user.PhoneNumber;
            userToBeUpdated.SchoolId = school[0].Id;

            _userDao.Update(userToBeUpdated);

            return Ok("İşlem başarılı.");
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userDao.GetById(x => x.Id == id);

            if (result == null)
            {
                return BadRequest("Böyle bir kullanıcı id si yok.İşlem başarısız.");
            }

            _userDao.Delete(result);

            return Ok("İşlem başarılı.");
        }
    }
}
