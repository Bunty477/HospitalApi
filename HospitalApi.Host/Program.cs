
using HospitalApi.Application.Cities;
using HospitalApi.Application.Contract.Cities;
using HospitalApi.Application.Contract.Departments;
using HospitalApi.Application.Contract.OPDPatient;
using HospitalApi.Application.Contract.PaymentTypes;
using HospitalApi.Application.Contract.Services;
using HospitalApi.Application.Contract.ServiceTypes;
using HospitalApi.Application.Contract.StaffDesignations;
using HospitalApi.Application.Contract.StaffLogins;
using HospitalApi.Application.Contract.Staffs;
using HospitalApi.Application.Contract.States;
using HospitalApi.Application.Departments;
using HospitalApi.Application.Designations;
using HospitalApi.Application.OPDApplicaion;
using HospitalApi.Application.PaymentTypes;
using HospitalApi.Application.Services;
using HospitalApi.Application.ServiceTypes;
using HospitalApi.Application.Staffs;
using HospitalApi.Application.States;
using HospitalApi.Data;
using HospitalApi.Designations;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program));

            var connection = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<HospitalContext>(
                x=>x.UseSqlServer(connection));
            
            builder.Services.AddTransient<IServiceApplication,ServiceApplication>();
            builder.Services.AddTransient<IStaffApplication,StaffApplication>();
            builder.Services.AddTransient<ICityApplication,CityApplication>();
            builder.Services.AddTransient<IStateApplication,StateApplication>();
            builder.Services.AddTransient<IOpdPatientApplication,OPDApplication>();
            builder.Services.AddTransient<IStaffDesignationApplication,DesignationApplication>();
            builder.Services.AddTransient<IServiceTypeApplication,ServiceTypeApplication>();
            builder.Services.AddTransient<IDepartementApplication, DepartmentApplication>();
            builder.Services.AddTransient<IPaymentTypeApplication,PaymentTypeApplication>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
