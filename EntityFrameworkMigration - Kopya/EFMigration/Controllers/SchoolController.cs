using AutoMapper;
using EntityFrameworkMigration.DataAccess.Abstract;
using EntityFrameworkMigration.DataAccess.Operations;
using EntityFrameworkMigration.Entities;
using EntityFrameworkMigration.Entities.DTO;
using EntityFrameworkMigration.ViewModels.SchoolViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolDao _schoolDao;
        private readonly ICityDao _cityDao;
        private readonly ISchoolTypeDao _schoolTypeDao;
        private readonly IMapper _mapper;

        public SchoolController(IMapper mapper, ISchoolDao schoolDao, ISchoolTypeDao schoolTypeDao, ICityDao cityDao)
        {
            _mapper = mapper;
            _schoolDao = schoolDao;
            _schoolTypeDao = schoolTypeDao;
            _cityDao = cityDao;
        }

        [HttpGet]
        public IActionResult GetAllWithDetails()
        {
            var schools = _schoolDao.GetSchoolsWithDetails();
            var schoolDetails = _mapper.Map<IEnumerable<SchoolDetailViewModel>>(schools);
            return Ok(schoolDetails);
        }


        [HttpGet("{id}")]
        public IActionResult GetSchoolById(int id)
        {
            var school = _schoolDao.GetSchoolsWithDetails(x => x.Id == id);
            if(school == null)
            {
                return BadRequest("Böyle bir okul id si yok. işlem başarısız.");
            }
            var schoolDetail = _mapper.Map<SchoolDetailViewModel>(school[0]);
            return Ok(schoolDetail);
        }

        [HttpPost]
        public IActionResult AddSchool([FromBody] SchoolDetailViewModel school)
        {
            var result = _schoolDao.GetAll(x => x.Name.ToLower() == school.Name.ToLower());
            var city = _cityDao.GetAll(x => x.Name.ToLower() == school.City.ToLower());
            var schoolType = _schoolTypeDao.GetAll(x => x.Name.ToLower() == school.SchoolType.ToLower());

            if (result.Count != 0)
            {
                return BadRequest("Böyle bir okul zaten mevcut.İşlem başarısız.");
            }
            if(city.Count == 0)
            {
                return BadRequest("Böyle bir şehir yok.Lütfen önce şehri ekleyiniz.");
            }
            if(schoolType.Count == 0)
            {
                return BadRequest("Böyle bir okul türü yok.Lütfen önce okul türünü ekleyiniz.");
            }

            School schoolToBeAdded = new School();
            schoolToBeAdded.Name = school.Name;
            schoolToBeAdded.CityId = city[0].Id;
            schoolToBeAdded.SchoolTypeId = schoolType[0].Id;

            _schoolDao.Add(schoolToBeAdded);

            return Ok("İşlem başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateSchool([FromBody] SchoolDetail school)
        {
            var result = _schoolDao.GetById(x => x.Id == school.Id);
            var city = _cityDao.GetAll(x => x.Name.ToLower() == school.CityName.ToLower());
            var schoolType = _schoolTypeDao.GetAll(x => x.Name.ToLower() == school.SchoolTypeName.ToLower());

            if (result == null)
            {
                return BadRequest("Böyle bir okul id si yok.İşlem başarısız.");
            }
            if (city.Count == 0)
            {
                return BadRequest("Böyle bir şehir yok.Lütfen önce şehri ekleyiniz.");
            }
            if (schoolType.Count == 0)
            {
                return BadRequest("Böyle bir okul türü yok.Lütfen önce okul türünü ekleyiniz.");
            }

            School schoolToBeUpdated = new School();
            schoolToBeUpdated.Id = school.Id;
            schoolToBeUpdated.Name = school.Name;
            schoolToBeUpdated.CityId = city[0].Id;
            schoolToBeUpdated.SchoolTypeId = schoolType[0].Id;

            _schoolDao.Update(schoolToBeUpdated);

            return Ok("İşlem başarılı.");
        }

        [HttpDelete("id")]
        public IActionResult DeleteSchool(int id)
        {
            var result = _schoolDao.GetById(x => x.Id == id);

            if(result == null)
            {
                return BadRequest("Böyle bir okul id si yok.İşlem başarısız.");
            }

            _schoolDao.Delete(result);

            return Ok("İşlem başarılı.");
        }

    }
}
