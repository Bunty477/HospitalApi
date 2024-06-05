using HospitalApi.Application.Contract.Cities;
using HospitalApi.Application.Contract.Departments;
using HospitalApi.Cities;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityApplication _cityApplication;
        private readonly IWebHostEnvironment _WebHostenvironment;
        public CityController(ICityApplication cityApplication,
            IWebHostEnvironment webHostenvironment)
        {
            _cityApplication = cityApplication;
            _WebHostenvironment = webHostenvironment;
        }
        [HttpPost]
        public async Task Post(CreateCityDto city)
        {
            await _cityApplication.Post(city);
        }
        [HttpGet]
        public async Task<List<City>> GetCities()
        {
            return await _cityApplication.GetCities();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecity(int id)
        {
            var data = await _cityApplication.Deletecity(id);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityId(int id )
        {
            var data = await _cityApplication.GetCityId(id);
            if (data == null)
            {
                return BadRequest("Id Not Found");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<City>> PutCity(int id ,CreateCityDto input)
        {
            var data = await _cityApplication.Put(id, input);
            return data;
        }
    }
}
