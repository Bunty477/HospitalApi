using HospitalApi.Application.Contract.Departments;
using HospitalApi.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartementApplication _application;
        private readonly IWebHostEnvironment _WebHostenvironment;
        public DepartmentController (IDepartementApplication application, 
            IWebHostEnvironment webHostenvironment)
        {
            _application = application;
            _WebHostenvironment = webHostenvironment;
        }
        [HttpPost]
        public async Task Post(CreateDepartmentDto input)
        {
            await _application.Post(input);
        }
        [HttpGet]
        public async Task<List<Department>> GetDepartments()
        {
            return await _application.GetDepartments();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDepartment(int id)
        {
            var data = await _application.DeleteDepartment(id);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentID(int id)
        {
            var data = await _application.GetDepartmentID(id);
            if (data == null)
            {
                return BadRequest("Id not Found");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> PutDepartment(int id ,CreateDepartmentDto input)
        {
            var data = await _application.Put(id, input);
            return null;
        }
    }
}
