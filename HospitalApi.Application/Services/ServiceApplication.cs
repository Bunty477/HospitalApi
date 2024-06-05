using AutoMapper;
using HospitalApi.Application.Contract.Services;
using HospitalApi.Data;
using HospitalApi.Services;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Application.Services;
public class ServiceApplication : IServiceApplication
{
    private readonly HospitalContext _context;
    private readonly IMapper _mapper;
    public ServiceApplication(HospitalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Post(CreateServiceDto input)
    {
        var service = new Service();
        service.Amount = input.Amount;
        service.StaffId = input.StaffId;
        service.ServiceTypeId = input.ServiceTypeId;
        _context.Services.Add(service);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Service>> GetService()
    {
        var service = await _context.Services.ToListAsync();
        return _mapper.Map<List<Service>>(service);
    }
    public async Task<Service> DeleteService(int id)
    {
        var data = await _context.Services.FindAsync(id);
        if (data != null)
        {
            _context.Services.Remove(data);
            await _context.SaveChangesAsync();
        }
        return null;
    }
    public async Task<Service> GetServiceId(int id )
    {
        var service = await _context.Services.FindAsync(id);
        if (service != null)
        {
            var data = _mapper.Map<Service>(service);
            return data;
        }
        return null;
    }
    public async Task<Service> Put(int id ,CreateServiceDto input)
    {
        var data = await _context.Services.FindAsync(id);
        if (data != null)
        {
            data.Amount = input.Amount;
            _context.Services.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return data;
    }
}
