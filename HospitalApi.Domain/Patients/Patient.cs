using HospitalApi.Cities;
using HospitalApi.Staffs;
using HospitalApi.States;

namespace HospitalApi.Patients;

public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int MobileNo { get; set; }
    public string Email { get; set; }
    public string FatherName { get; set; }
    public int Age { get; set; }
    public string Sex { get; set; }
    public string Disease { get; set; }
    public string? BloodGroup { get; set; }
    public DateTime RegisterDate { get; set; }
    public string Address { get; set; }
    public City? City { get; set; }
    public State? State { get; set; }
    public Staff? Staff { get; set; }
}
