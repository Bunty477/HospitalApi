using HospitalApi.Application.Contract.Staffs;
using HospitalApi.Staffs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffApplication _staffApplication;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StaffController(IStaffApplication staffApplication, IWebHostEnvironment webHostEnvironment)
        {
            _staffApplication = staffApplication;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task Post([FromForm]CreateStaffDto input)
        {
            await _staffApplication.Post(input);
        }
        [HttpGet]
        public async Task<List<Staff>> GetStaff()
        {
            return await _staffApplication.GetStaff();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffId(int id )
        {
            var data = await _staffApplication.DeleteStaffId(id);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffID(int id )
        {
            var data = await _staffApplication.GetStaffID(id);
            if (data == null)
            {
                return BadRequest("Id Not Found");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> Put(int id , CreateStaffDto input)
        {
            var data = await _staffApplication.Put(id, input);
            return null;
        }
    }
}
