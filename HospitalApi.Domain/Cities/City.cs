using HospitalApi.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Cities;
public class City
{
    public int Id { get; set; }
    public string CityName { get; set; }
    public int StateId { get; set; }
    public State State { get; set; }
}
