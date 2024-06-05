using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.OPDPatient;
public class CreateOpdPatientDto
{
    public string FullName {  get; set; }
    public string FatherName { get; set; }
    public int Age { get; set; }
    public string Sex { get; set; }
    public string Disease { get; set; }
    public int MobileNO { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public decimal Amount { get; set; }
    public decimal Discount { get; set; }
    public decimal NetAmount { get; set; }
}
