using HospitalApi.Cities;
using HospitalApi.Departments;
using HospitalApi.Designations;
using HospitalApi.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.Staffs
{
    public class CreateStaffDto
    {
        public string FullName { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        //public int CityID { get; set; }
        //public City City { get; set; }
        //public int StateId { get; set; }
        //public int DepartmentID { get; set; }
        //public Department Department { get; set; }
        //public int DesignationId { get; set; }
        //public Designation Designation { get; set; }
    }
}
