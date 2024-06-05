using AutoMapper;
using HospitalApi.Application.Contract.Cities;
using HospitalApi.Cities;
using HospitalApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Application.Cities
{
    public class CityApplication : ICityApplication
    {
        private readonly HospitalContext _context;
        private readonly IMapper _mapper;
        public CityApplication(HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Post(CreateCityDto input)
        {
            var city = new City();
            city.CityName = input.CityName;
            city.StateId = input.StateId;

            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }
        public async Task<List<City>> GetCities()
        {
            var city = await _context.Cities.ToListAsync();
            return _mapper.Map<List<City>>(city);
        }
        public async Task<City> Deletecity(int id)
        {
            var data = await _context.Cities.FindAsync(id);
            if (data != null)
            {
                _context.Cities.Remove(data);
                await _context.SaveChangesAsync();
            }
            return null;
        }
        public async Task<City> GetCityId(int id)
        {
            var data = await _context.Cities.FindAsync(id);
            if (data != null)
            {
                var city = _mapper.Map<City>(data);
                return data;
            }
            return null;
        }
        public async Task<City> Put(int id, CreateCityDto input)
        {
            var data = await _context.Cities.FindAsync(id);
            if (data != null)
            {
                data.CityName = input.CityName;
                data.StateId = input.StateId;
                _context.Cities.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return data;
        }
    }
}
