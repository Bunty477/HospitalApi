using HospitalApi.Application.Contract.Services;
using HospitalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceApplication _serviceApplication;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceController(IServiceApplication serviceApplication, IWebHostEnvironment webHostEnvironment)
        {
            _serviceApplication = serviceApplication;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task Post(CreateServiceDto input)
        {
            await _serviceApplication.Post(input);
        }
        [HttpGet]
        public async Task<List<Service>> Get()
        {
            return await _serviceApplication.GetService();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var data = await _serviceApplication.DeleteService(id);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServiceId(int id)
        {
            var data = await _serviceApplication.GetServiceId(id);
                if (data == null)
            {
                return BadRequest("Id Not Found");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> Put(int id ,CreateServiceDto input)
        {
            var data = await _serviceApplication.Put(id, input);
            return null;
        }
    }
}
