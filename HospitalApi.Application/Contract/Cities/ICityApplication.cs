using HospitalApi.Cities;

namespace HospitalApi.Application.Contract.Cities
{
    public interface ICityApplication
    {
        Task Post(CreateCityDto city);
        Task<List<City>> GetCities();
        Task<City> GetCityId(int id);
        Task<City> Deletecity(int id);
        Task<City> Put(int id, CreateCityDto city);
        //Task Post(CreateDepartmentDto input);
        //Task<List<Department>> GetDepartments();
        //Task<Department> GetDepartmentID(int id);
        //Task<Department> DeleteDepartment(int id);
        //Task<Department> Put(int id, CreateDepartmentDto input);
    }
}
