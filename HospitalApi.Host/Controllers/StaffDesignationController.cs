using HospitalApi.Application.Contract.StaffDesignations;
using HospitalApi.Designations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffDesignationController : ControllerBase
    {
        private readonly IStaffDesignationApplication _designationApplication;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StaffDesignationController (IStaffDesignationApplication designationApplication
            , IWebHostEnvironment webHostEnvironment)
        {
            _designationApplication = designationApplication;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<List<Designation>> GetDesignations()
        {
            return await _designationApplication.GetDesignations();
        }
        [HttpPost]
        public async Task Post (StaffDesignationDto input)
        {
            await _designationApplication.Post(input);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDesignation(int id)
        {
            var data = await _designationApplication.DeleteDesignation(id);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Designation>> GetDesignationId(int id)
        {
            var data = await _designationApplication.GetDesignationId(id);
            if (data == null)
            {
                return BadRequest("Id Not Found");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Designation>> PutStaffDesignation(int id, StaffDesignationDto input)
        {
            var data = await _designationApplication.Put(id, input);
            return Ok(data);
        }
    }
}
