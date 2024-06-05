
using HospitalApi.Domain.StaffLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.UpdatePassword;
public interface IUpdatePasswordApplication
{
    Task<StaffLogin> UpdatePassword(int id, UpdatePasswordDto password);
    Task<StaffLogin> ForgetPassword(long number);
    Task<StaffLogin> ForgetPasswordmail(string email);
}
