using AutoMapper;
using HospitalApi.Application.Contract.Staffs;
using HospitalApi.Data;
using HospitalApi.Domain.StaffLogin;
using HospitalApi.Staffs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Staffs
{
    public class StaffApplication : IStaffApplication
    {
        private readonly HospitalContext _context;
        private readonly IMapper _mapper;
        public StaffApplication (HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Staff> DeleteStaffId(int id)
        {
            var data = await _context.Staffs.FindAsync(id);
            if (data != null)
            {
                _context.Staffs.Remove(data);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<List<Staff>> GetStaff()
        {
            var data = await _context.Staffs.ToListAsync();
            return _mapper.Map<List<Staff>>(data);
        }

        public async Task<Staff> GetStaffID(int id)
        {
            var data = await _context.Staffs.FindAsync(id);
            if (data != null)
            {
                var staff = _mapper.Map<Staff>(data);
                return staff;
            }
            return null;
        }

        public async Task Post(CreateStaffDto input)
        {
            var data = new Staff();
            data.FullName = input.FullName;
            data.MobileNo = input.MobileNo;
            data.Email = input.Email;
            data.Sex = input.Sex;
            data.Address = input.Address;
            data.StateId = input.StateId;
            data.CityId = input.CityId;
            data.DepartmentId = input.DepartmentId;
            data.DesignationID = input.DesignationId;
            _context.Staffs.Add(data);
            await _context.SaveChangesAsync();

            var insert = new StaffLogin();
            insert.StaffId = data.Id;
            insert.UserName = input.UserName;
            insert.Password = input.Password;
            insert.IsActive = input.IsActive;
            _context.StaffLogins.Add(insert);
            await _context.SaveChangesAsync();

        }

        public async Task<Staff> Put(int id, CreateStaffDto input)
        {
           var data = await _context.Staffs.FindAsync(id);
            if (data != null)
            {
                data.FullName = input.FullName;
                data.MobileNo = input.MobileNo;
                data.Email = input.Email;
                data.Sex = input.Sex;
                data.Address = input.Address;
                _context.Staffs.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return data;
        }
        public async Task<StaffLogin> Login(string username, string password)
        {
            var data= await _context.StaffLogins.Where(x=>x.UserName==username&&x.Password==password).FirstOrDefaultAsync();
           /* var data = await _context.StaffLogins.
                Where(x => x.UserName == UserName && x.Password == Password).
                FirstOrDefaultAsync();*/
            if (data != null)
            {
                return data;
            }
            return null;
        }
    }
}
