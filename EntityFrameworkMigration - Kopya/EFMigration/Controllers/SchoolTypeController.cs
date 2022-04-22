using EntityFrameworkMigration.DataAccess.Abstract;
using EntityFrameworkMigration.DataAccess.Operations;
using EntityFrameworkMigration.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkMigration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolTypeController : Controller
    {
        private readonly ISchoolTypeDao _schoolTypeDao;

        public SchoolTypeController(ISchoolTypeDao schoolTypeDao)
        {
            _schoolTypeDao = schoolTypeDao;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(_schoolTypeDao.GetAll());
        }

        [HttpPost]
        public IActionResult AddSchoolType([FromBody] SchoolType schoolType)
        {
            var result = _schoolTypeDao.GetById(x => x.Name == schoolType.Name);
            if (result != null)
            {
                return BadRequest("Böyle bir okul türü zaten mevcut. İşlem başarısız");
            }
            _schoolTypeDao.Add(schoolType);
            return Ok("İşlem başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchoolType(int id)
        {
            var result = _schoolTypeDao.GetById(x => x.Id == id);
            if (result == null)
            {
                return BadRequest("Böyle bir şehir id si yok. İşlem başarısız");
            }
            _schoolTypeDao.Delete(result);
            return Ok("İşlem başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateCity([FromForm] SchoolType schoolType)
        {
            var result = _schoolTypeDao.GetById(x => x.Id == schoolType.Id);
            if (result == null)
            {
                return BadRequest("Böyle bir şehir id si yok. İşlem başarısız");
            }
            _schoolTypeDao.Update(schoolType);
            return Ok("İşlem başarılı.");
        }
    }
}
