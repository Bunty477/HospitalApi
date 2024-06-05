using HospitalApi.Designations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.StaffDesignations
{
    public interface IStaffDesignationApplication
    {
        Task Post(StaffDesignationDto input);
        Task<List<Designation>> GetDesignations();
        Task<Designation> GetDesignationId(int id);
        Task<Designation> DeleteDesignation(int id);
        Task<Designation> Put(int id , StaffDesignationDto input);
    }
}
