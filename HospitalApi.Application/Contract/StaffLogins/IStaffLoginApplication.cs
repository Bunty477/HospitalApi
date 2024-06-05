namespace HospitalApi.Application.Contract.StaffLogins
{
    public interface IStaffLoginApplication
    {

        Task PostLogin(CreateStaffLoginDto input);
    }
}
