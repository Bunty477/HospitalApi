using HospitalApi.States;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.Cities;

public class CreateCityDto
{
    public string CityName { get; set; }
    public int StateId { get; set; }
}
