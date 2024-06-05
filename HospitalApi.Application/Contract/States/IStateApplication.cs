using HospitalApi.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.Contract.States
{
    public interface IStateApplication
    {
        Task Post(CreateStateDto state);
        Task<List<State>> GetStates();
        Task<State> GetStateId(int id );
        Task<State> DeleteState(int id);
        Task<State> Put(int id ,CreateStateDto state);
    }
}
