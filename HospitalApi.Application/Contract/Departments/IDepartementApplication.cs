using HospitalApi.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.Departments
{
    public interface IDepartementApplication
    {
        Task Post(CreateDepartmentDto input);
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentID(int id);
        Task<Department> DeleteDepartment(int id);
        Task <Department> Put(int id , CreateDepartmentDto input);
    }
}
