using AutoMapper;
using Azure.Core;
using HospitalApi.Application.Contract.StaffDesignations;
using HospitalApi.Data;
using HospitalApi.Designations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Designations;

public class DesignationApplication : IStaffDesignationApplication
{
    private readonly HospitalContext _context;
    private readonly IMapper _mapper;
    public DesignationApplication(HospitalContext context
        , IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<Designation>> GetDesignations()
    {
        var staffDesignation = await _context.Designations.ToListAsync();
        return _mapper.Map<List<Designation>>(staffDesignation);
    }
    public async Task Post(StaffDesignationDto input)
    {
        var designation = new Designation();
        designation.DesignationName = input.DesignationName;

        _context.Designations.Add(designation);
        await _context.SaveChangesAsync();
    }
    public async Task<Designation> DeleteDesignation(int id)
    {
        var data = await _context.Designations.FindAsync(id);
        if (data != null)
        {
            _context.Designations.Remove(data);
            await _context.SaveChangesAsync();
        }
        return null;
    }
    public async Task<Designation> GetDesignationId(int id)
    {
        var designation = await _context.Designations.FindAsync(id);
        if (designation != null)
        {
            var data = _mapper.Map<Designation>(designation);
            return data;
        }
        return null;
    }
    public async Task<Designation> Put(int id ,StaffDesignationDto input)
    {
        var data = await _context.Designations.FindAsync(id);
        if (data != null)
        {
            data.DesignationName = input.DesignationName;
            _context.Designations.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return data;
    }
}
