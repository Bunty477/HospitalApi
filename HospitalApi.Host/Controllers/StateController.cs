using HospitalApi.Application.Contract.States;
using HospitalApi.States;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateApplication _stateApplication;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StateController(IStateApplication stateApplication, IWebHostEnvironment webHostEnvironment)
        {
            _stateApplication = stateApplication;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task Post(CreateStateDto input)
        {
            await _stateApplication.Post(input);
        }
        [HttpGet]
        public async Task<List<State>> GetStates()
        {
            return await _stateApplication.GetStates();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            var data = await _stateApplication.DeleteState(id);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetStateId(int id )
        {
            var data = await _stateApplication.GetStateId(id);
            if (data == null)
            {
                return BadRequest("Id Not Found");
            }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<State>> Put(int id ,CreateStateDto input)
        {
            var data = await _stateApplication.Put(id , input);
            return null;
        }
    }
}
