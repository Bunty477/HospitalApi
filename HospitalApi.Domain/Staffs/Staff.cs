using HospitalApi.Cities;
using HospitalApi.Departments;
using HospitalApi.Designations;
using HospitalApi.States;

namespace HospitalApi.Staffs
{
    public class Staff
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string? Image { get; set; }
        public string Address { get; set; }
        public DateTime JoiningDate { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int DesignationID { get; set; }
        public Designation Designation { get; set; }
    }
}
