using AutoMapper;
using HospitalApi.Application.Contract.OPDPatient;
using HospitalApi.Data;
using HospitalApi.OPDs;
using HospitalApi.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.OPDApplicaion;

public class OPDApplication:IOpdPatientApplication
{
    private readonly HospitalContext _context;
    private readonly IMapper _mapper;
    public OPDApplication(HospitalContext context
        , IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Post(CreateOpdPatientDto input)
    {
        var patient = new Patient();
        var opd = new OPD();
        patient.FullName = input.FullName;
        patient.FatherName = input.FatherName;
        patient.Address = input.Address;
        patient.Age = input.Age;
        patient.Disease = input.Disease;
        patient.Email = input.Email;
        patient.MobileNo = input.MobileNO;
        patient.Sex = input.Sex;
        opd.Amount = input.Amount;
        opd.Discount = input.Discount;
        opd.NetAmount = input.NetAmount;
        _context.Patients.Add(patient);
        _context.OPDs.Add(opd);
        await _context.SaveChangesAsync();
        await _context.SaveChangesAsync();
    }
}
