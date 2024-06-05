using HospitalApi.ServiceTypes;
using HospitalApi.Staffs;

namespace HospitalApi.Services;
public class Service
{
    public int Id { get; set; }
    public int ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedDate { get; set; }
    public int StaffId { get; set; }
    public Staff Staff { get; set; }
}
