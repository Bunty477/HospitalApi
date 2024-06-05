using HospitalApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.Services;
public interface IServiceApplication
{
    Task Post(CreateServiceDto input);
    Task<List<Service>> GetService();
    Task<Service> GetServiceId(int id);
    Task<Service> DeleteService(int id);
    Task<Service> Put(int id ,CreateServiceDto input);
}
