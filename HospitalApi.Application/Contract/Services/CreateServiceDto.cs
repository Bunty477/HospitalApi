using HospitalApi.ServiceTypes;
using HospitalApi.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.Services;
public class CreateServiceDto
{
    public int ServiceTypeId { get; set; }
    public decimal Amount { get; set; }
    public int StaffId { get; set; }
}
