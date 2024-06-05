using HospitalApi.Staffs;

namespace HospitalApi.Salaries;

public class Salary
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PayDate { get; set; }
    public Staff Staff { get; set; }
    public string? Remaning { get; set; }
}
