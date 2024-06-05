using HospitalApi.Application.Contract.ServiceTypes;
using HospitalApi.PaymentTypes;
using HospitalApi.ServiceTypes;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeApplication _serviceType;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceTypeController(IServiceTypeApplication serviceType
            , IWebHostEnvironment webHostEnvironment)
        {
            _serviceType = serviceType;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<List<ServiceType>> GetServiceTypes()
        {
            return await _serviceType.GetServiceTypes();
        }
        [HttpPost]
        public async Task Post(ServiceTypeDto input)
        {
            await _serviceType.Post(input);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveServiceType(int id)
        {
            var data = await _serviceType.DeleteServiceType(id);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceType>> GetServiceTypeId(int id)
        {
            var data = await _serviceType.GetServiceTypeId(id);
            if (data == null)
            {
                return BadRequest("Id not Found");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceType>> PutServiceType(int id, ServiceTypeDto input)
        {
            var data = await _serviceType.Put(id, input);
            return null;
        }
    }
}
