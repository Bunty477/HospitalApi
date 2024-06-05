using AutoMapper;
using HospitalApi.Application.Contract.Departments;
using HospitalApi.Application.Contract.PaymentTypes;
using HospitalApi.Data;
using HospitalApi.Departments;
using HospitalApi.PaymentTypes;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Application.PaymentTypes;
public class PaymentTypeApplication : IPaymentTypeApplication
{
    private readonly HospitalContext _context;
    private readonly IMapper _mapper;
    public PaymentTypeApplication(HospitalContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PaymentType>> GetPaymentTypes()
    {
        var paymentType = await _context.PaymentTypes.ToListAsync();
        return _mapper.Map<List<PaymentType>>(paymentType);
    }

    public async Task Post(PaymentTypeDto input)
    {
        var paymentType = new PaymentType();
        paymentType.Type = input.Type;

        _context.PaymentTypes.Add(paymentType);
        await _context.SaveChangesAsync();
    }
    public async Task<PaymentType> DeletePaymentType(int id)
    {
        var data = await _context.PaymentTypes.FindAsync(id);
        if (data != null)
        {
            _context.PaymentTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
        return null;
    }

    public async Task<PaymentType> GetPaymentTypeId(int id)
    {
        var paymentType = await _context.PaymentTypes.FindAsync(id);
        if (paymentType != null)
        {
            var data = _mapper.Map<PaymentType>(paymentType);
            return data;
        }
        return null;
    }

    public async Task<PaymentType> Put(int id, PaymentTypeDto input)
    {
        var data = await _context.PaymentTypes.FindAsync(id);
        if ( data != null)
        {
            data.Type = input.Type;
            _context.PaymentTypes.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return data;
    }
}
