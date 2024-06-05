using HospitalApi.PaymentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.PaymentTypes;
public interface IPaymentTypeApplication
{
    Task Post(PaymentTypeDto input);
    Task<List<PaymentType>> GetPaymentTypes();
    Task<PaymentType> GetPaymentTypeId(int id);
    Task<PaymentType> DeletePaymentType(int id);
    Task<PaymentType> Put(int id , PaymentTypeDto input);
}
