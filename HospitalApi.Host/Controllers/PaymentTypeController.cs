using HospitalApi.Application.Contract.Departments;
using HospitalApi.Application.Contract.PaymentTypes;
using HospitalApi.Departments;
using HospitalApi.PaymentTypes;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeApplication _typeApplication;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PaymentTypeController(IPaymentTypeApplication typeApplication
            , IWebHostEnvironment webHostEnvironment)
        {
            _typeApplication = typeApplication;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<List<PaymentType>> GetPaymentTypes()
        {
            return await _typeApplication.GetPaymentTypes();
        }
        [HttpPost]
        public async Task Post(PaymentTypeDto input)
        {
            await _typeApplication.Post(input);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePaymentType(int id)
        {
            var data = await _typeApplication.DeletePaymentType(id);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentType>> GetPaymentTypeId(int id)
        {
            var data = await _typeApplication.GetPaymentTypeId(id);
            if (data == null)
            {
                return BadRequest("Id not Found");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentType>> PutPaymentType(int id, PaymentTypeDto input)
        {
            var data = await _typeApplication.Put(id, input);
            return null;
        }
    }
}
