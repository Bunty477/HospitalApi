using HospitalApi.Cities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.States;
public class State
{
    [Key]
    public int Id { get; set; }
    public string StateName { get; set; }
}
