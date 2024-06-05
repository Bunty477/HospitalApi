using HospitalApi.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Domain.StaffLogin;
public class StaffLogin
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public int StaffId { get; set;}
    public Staff staff { get; set; }
}
