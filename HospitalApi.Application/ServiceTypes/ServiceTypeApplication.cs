using AutoMapper;
using Azure.Core;
using HospitalApi.Application.Contract.ServiceTypes;
using HospitalApi.Data;
using HospitalApi.ServiceTypes;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Application.ServiceTypes;

public class ServiceTypeApplication : IServiceTypeApplication
{
    private readonly HospitalContext _context;
    private readonly IMapper _mapper;
    public ServiceTypeApplication(HospitalContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ServiceType>> GetServiceTypes()
    {
        var serviceType = await _context.ServiceTypes.ToListAsync();
        return _mapper.Map<List<ServiceType>>(serviceType);
    }

    public async Task Post(ServiceTypeDto input)
    {
        var serviceType = new ServiceType();
        serviceType.TypeName = input.TypeName;

        _context.ServiceTypes.Add(serviceType);
        await _context.SaveChangesAsync();
    }
    public async Task<ServiceType> DeleteServiceType(int id)
    {
        var data = await _context.ServiceTypes.FindAsync(id);
        if (data != null)
        {
            _context.ServiceTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
        return null;
    }

    public async Task<ServiceType> GetServiceTypeId(int id)
    {
        var serviceType = await _context.ServiceTypes.FindAsync(id);
        if (serviceType != null)
        {
            var data = _mapper.Map<ServiceType>(serviceType);
            return data;
        }
        return null;
    }
    public async Task<ServiceType> Put(int id ,ServiceTypeDto input)
    {
        var data = await _context.ServiceTypes.FindAsync(id);
        if (data != null)
        {
            data.TypeName = input.TypeName;
            _context.ServiceTypes.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return data;
    }
}
