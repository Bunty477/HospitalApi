using HospitalApi.Application.Contract.PaymentTypes;
using HospitalApi.PaymentTypes;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.OPDPatient;
public interface IOpdPatientApplication
{
    Task Post(CreateOpdPatientDto input);
    
    //Task<List<PaymentType>> GetPaymentTypes();
    //Task<PaymentType> GetPaymentTypeId(int id);
    //Task<PaymentType> DeletePaymentType(int id);
    //Task<PaymentType> Put(int id, PaymentTypeDto input);
}
