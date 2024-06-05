using AutoMapper;
using HospitalApi.Application.Contract.Departments;
using HospitalApi.Departments;

namespace HospitalApi.Host
{
    public class HospitalAutoMapper:Profile
    {
        public HospitalAutoMapper()
        {
            CreateMap<Department,CreateDepartmentDto>();
        }
    }
}
