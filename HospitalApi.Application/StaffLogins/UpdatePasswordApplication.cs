using Application.Contracts.Services;
using HospitalApi.Application.Contract.UpdatePassword;
using HospitalApi.Data;
using HospitalApi.Domain.StaffLogin;
using HospitalApi.LoginServices;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Application.StaffLogins
{
    public class UpdatePasswordApplication : IUpdatePasswordApplication
    {
        private readonly HospitalContext _context;
        private readonly IWhatsAppService _service;
        public UpdatePasswordApplication(HospitalContext context, IWhatsAppService service)
        {
            _context = context;
            _service = service;
        }
        public async Task<StaffLogin> ForgetPassword(long number)
        {
            var data = await _context.StaffLogins.
                Include(x => x.staff).
                Where(x => x.staff.MobileNo == number).FirstOrDefaultAsync();
            if (data != null)
            {
                var Message = $"{data.UserName},your old password is ({data.Password})";
                long tonumber = (long)data.staff.MobileNo;
                await _service.SendMessage(9991180404, tonumber, Message);
                return data;
            }
            return null;
        }
        public async Task<StaffLogin> ForgetPasswordmail(string email)
        {
            var data = await _context.StaffLogins.
                Include(x => x.staff).
                Where(x => x.staff.Email == email).FirstOrDefaultAsync();
            if (data != null)
            {
                string emailBody = $"Your username ({data.UserName}) and your password is ({data.Password})";
                string Subject = "your code and password";
                EmailAppService service = new EmailAppService();
                service.SendEmail(email, Subject, emailBody);
                return data;
            }
            return null;
        }
        public async Task<StaffLogin> UpdatePassword(int id, UpdatePasswordDto password)
        {
            var data = await _context.StaffLogins.
                Include(x => x.StaffId).Where(x => x.StaffId == id).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new Exception("User Not Found");
            }
            if (data.Password != password.OldPassword)
            {
                throw new Exception("Old Password not match");
            }
            if (data.Password == password.NewPassword)
            {
                throw new Exception("New password is diffrent from Old Password ");
            }
            data.Password = password.NewPassword;
            _context.StaffLogins.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
