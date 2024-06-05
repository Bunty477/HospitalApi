using HospitalApi.Application.Contract.StaffLogins;
using HospitalApi.Application.Contract.Staffs;
using HospitalApi.Application.Contract.UpdatePassword;
using HospitalApi.Domain.StaffLogin;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Host.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StaffLoginController : ControllerBase
{
    private readonly IUpdatePasswordApplication _passwordApplication;
    private readonly IStaffApplication _application;
    public StaffLoginController(IStaffApplication application,IUpdatePasswordApplication passwordApplication)
    {
       _application = application;
       _passwordApplication = passwordApplication;
        
    }
    [HttpPost("Login")]
    public async Task<ActionResult<GetStaffLoginDto>> PostLogin(string userName,string password)
    {
        var data = await _application.Login(userName, password);
        if (data == null)
        {
            return Ok(data);
        }
        return BadRequest("password or username not matched");
    }
    [HttpPut("{id}/update-password")]
    public async Task<ActionResult<StaffLogin>> UpdatePassword(int id ,UpdatePasswordDto password)
    {
        try
        {
            var data = await _passwordApplication.UpdatePassword(id, password);
            return Ok(data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("ForgetPassword")]
    public async Task<ActionResult<StaffLogin>> ForgetPassword(long number)
    {
        var data = await _passwordApplication.ForgetPassword(number);
        if (data == null)
        {
            return BadRequest("M.No Not Found");
        }
        return Ok("Old Password is Send ");
    }
    [HttpPut("Email")]
    public async Task<ActionResult<StaffLogin>> ForgetPasswordmails(string email)
    {
        var data = await _passwordApplication.ForgetPasswordmail(email);
        if (data == null)
        {
            return BadRequest("Email Is Incorrect");
        }
        return Ok("Mail Send");
    }
}