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
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityDao _eFCityDao;

        public CityController(ICityDao cityDao)
        {
            _eFCityDao = cityDao;
        }

        [HttpPost]
        public IActionResult AddCity([FromBody] City city)
        {
            var result = _eFCityDao.GetById(x => x.Name.ToLower() == city.Name.ToLower());
            if(result != null)
            {
                return BadRequest("Şehir zaten var.İşlem başarısız.");
            }
            _eFCityDao.Add(city);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllCity()
        {
            return Ok(_eFCityDao.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var result = _eFCityDao.GetById(x => x.Id == id);
            if(result == null)
            {
                return BadRequest("Böyle bir şehir id si yok. İşlem başarısız");
            }
            _eFCityDao.Delete(result);
            return Ok("İşlem başarılı.");
        }
           
        [HttpPut]
        public IActionResult UpdateCity([FromForm] City city)
        {
            var result = _eFCityDao.GetById(x => x.Id == city.Id);
            if (result == null)
            {
                return BadRequest("Böyle bir şehir id si yok. İşlem başarısız");
            }
            _eFCityDao.Update(city);
            return Ok("İşlem başarılı.");
        }
    }
}
