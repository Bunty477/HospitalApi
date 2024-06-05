using HospitalApi.Cities;
using HospitalApi.Departments;
using HospitalApi.Designations;
using HospitalApi.Domain.StaffLogin;
using HospitalApi.OPDs;
using HospitalApi.Patients;
using HospitalApi.Payments;
using HospitalApi.PaymentTypes;
using HospitalApi.Salaries;
using HospitalApi.Services;
using HospitalApi.ServiceTypes;
using HospitalApi.Staffs;
using HospitalApi.States;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<OPD> OPDs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<StaffLogin> StaffLogins { get; set;}
    }
}
