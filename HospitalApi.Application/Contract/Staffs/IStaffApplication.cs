using HospitalApi.Domain.StaffLogin;
using HospitalApi.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.Staffs
{
    public interface IStaffApplication
    {
        Task Post(CreateStaffDto input);
        Task<List<Staff>> GetStaff();
        Task<Staff> DeleteStaffId(int id);
        Task<Staff> GetStaffID(int id);
        Task<Staff> Put(int id ,CreateStaffDto input);
        Task<StaffLogin> Login(string username,string password);
    }
}
