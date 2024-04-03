using CountryAPI.Interfaces;
using CountryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Repository
{
    public class CityRepository: ICityRepository
    {
           
            private readonly ApplicationDbContext _context;
            public CityRepository(ApplicationDbContext context/*, IMongoClient client*/)
            {
                
                _context = context;
            }

            public async Task<bool> AddCity(City city)
            {
                try
                {

                    //await _countries.InsertOneAsync(country);
                    //return true;
                    await _context.Cities.AddAsync(city);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            //public async Task<Country> GetCountryByCountryName(string countryName)
            //{
            //    var filterdata = Builders<Country>.Filter.Eq(x => x.Name, countryName);
            //    var country = await _countries.Find(filterdata).FirstOrDefaultAsync();
            //    return country;
            //}

            public async Task<List<City>> GetCityByCityName(string cityName)
            {
                //var filterdata = Builders<Country>.Filter.Eq(x => x.Name, countryName);
                //var country = _countries.Find(filterdata).FirstOrDefaultAsync();
                //return country

                return await _context.Cities.Where(x => x.CityName == cityName).ToListAsync();
            }

       

        public async Task<bool> UpdateCity(City city)
            {
                try
                {
                    _context.Cities.Update(city);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                };
            }
        }
}
