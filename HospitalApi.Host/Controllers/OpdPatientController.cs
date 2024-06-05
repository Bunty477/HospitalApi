using HospitalApi.Application.Contract.OPDPatient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpdPatientController : ControllerBase
    {
        private readonly IOpdPatientApplication _opdPatientApplication;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public OpdPatientController(IOpdPatientApplication opdPatientApplication, 
            IWebHostEnvironment webHostEnvironment)
        {
            _opdPatientApplication = opdPatientApplication;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task Post([FromForm] CreateOpdPatientDto input)
        {
            await _opdPatientApplication.Post(input);
        }
    }
}