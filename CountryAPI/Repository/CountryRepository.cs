using CountryAPI.Interfaces;
using CountryAPI.Model;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CountryAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
        //private readonly IMongoCollection<Country> _countries;

        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context/*, IMongoClient client*/)
        {
            //var database = client.GetDatabase("CountryDB");
            //var collection = database.GetCollection<Country>(nameof(Country));
            //_countries = collection;
            _context = context;
        }

        public async Task<bool> AddCountry(Country country)
        {
            try
            {

                //await _countries.InsertOneAsync(country);
                //return true;
                await _context.Countries.AddAsync(country);
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

        public async Task<List<Country>> GetCountryByCountryName(string countryName)
        {
            //var filterdata = Builders<Country>.Filter.Eq(x => x.Name, countryName);
            //var country = _countries.Find(filterdata).FirstOrDefaultAsync();
            //return country

            return await _context.Countries.Where(x => x.Name == countryName).ToListAsync();
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            try
            {
                _context.Countries.Update(country);
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
