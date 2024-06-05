using HospitalApi.Patients;
using HospitalApi.Services;
using HospitalApi.Staffs;

namespace HospitalApi.OPDs
{
    public class OPD
    {

        public int Id { get; set; }
        public Patient? Patient { get; set; }
        public DateTime RegisterDate { get; set; }
        public Service? Service { get; set; }
        public DateTime OPDDate { get; set; }
        public Staff? Staff { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime ValidDate { get; set; }
        public string? Day {  get; set; }
    }
}
