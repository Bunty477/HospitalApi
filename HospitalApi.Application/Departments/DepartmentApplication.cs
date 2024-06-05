using AutoMapper;
using HospitalApi.Application.Contract.Departments;
using HospitalApi.Data;
using HospitalApi.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Departments;

public class DepartmentApplication : IDepartementApplication
{
    private readonly HospitalContext _context;
    private readonly IMapper _mapper;
    public DepartmentApplication (HospitalContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task Post(CreateDepartmentDto input)
    {
        var department = new Department();
        department.Name = input.Name;

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Department>> GetDepartments()
    {
        var department = await _context.Departments.ToListAsync();
        return _mapper.Map<List<Department>>(department);
    }
    public async Task<Department> DeleteDepartment(int id)
    {
        var data = await _context.Departments.FindAsync(id);
        if (data != null)
        {
            _context.Departments.Remove(data);
            await _context.SaveChangesAsync();
        }
        return null;
    }
    public async Task<Department> GetDepartmentID(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            var data = _mapper.Map<Department>(department);
            return data;
        }
        return null;
    }

    public async Task<Department> Put(int id, CreateDepartmentDto input)
    {
        var data = await _context.Departments.FindAsync (id);
        if (data != null)
        {
            data.Name = input.Name;
            _context.Departments.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return data;
    }
}
