using HospitalApi.ServiceTypes;

namespace HospitalApi.Application.Contract.ServiceTypes
{
    public interface IServiceTypeApplication
    {
        Task Post(ServiceTypeDto input);
        Task<List<ServiceType>> GetServiceTypes();
        Task<ServiceType> GetServiceTypeId(int id);
        Task<ServiceType> DeleteServiceType(int id);
        Task<ServiceType> Put(int id , ServiceTypeDto input);
    }
}
