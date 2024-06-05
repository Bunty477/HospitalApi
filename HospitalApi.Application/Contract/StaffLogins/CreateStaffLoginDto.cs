using HospitalApi.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.StaffLogins
{
    public class CreateStaffLoginDto
    {
        public int StaffId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
