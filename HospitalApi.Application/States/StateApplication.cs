using AutoMapper;
using HospitalApi.Application.Contract.States;
using HospitalApi.Data;
using HospitalApi.States;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Application.States;
public class StateApplication : IStateApplication
{
    private readonly HospitalContext _context;
    private readonly IMapper _mapper;
    public StateApplication(HospitalContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Post(CreateStateDto input)
    {
        var data = new State();
        data.StateName = input.StateName;
        _context.States.Add(data);
        await _context.SaveChangesAsync();
    }
    public async Task<List<State>> GetStates()
    {
        var states = await _context.States.ToListAsync();
        return _mapper.Map<List<State>>(states);
    }

    public async Task<State> GetStateId(int id)
    {
        var state = await _context.States.FindAsync(id);
        if (state !=  null)
        {
            var data = _mapper.Map<State>(state);
            return data;
        }
        return null;
    }

    public async Task<State> DeleteState(int id)
    {
       var data = await _context.States.FindAsync(id);
        if(data != null)
        {
            _context.States.Remove(data);
            await _context.SaveChangesAsync();
        }
        return null;
    }

    public async Task<State> Put(int id, CreateStateDto state)
    {
        var data = await _context.States.FindAsync(id);
        if (data != null)
        {
            data.StateName = state.StateName;
            _context.States.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
        return data;
    }
}
