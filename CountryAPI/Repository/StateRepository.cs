using CountryAPI.Interfaces;
using CountryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CountryAPI.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context/*, IMongoClient client*/)
        {

            _context = context;
        }

        public async Task<bool> AddState(State state)
        {
            try
            {

                //await _countries.InsertOneAsync(country);
                //return true;
                await _context.States.AddAsync(state);
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

        public async Task<List<State>> GetStateByStateName(string stateName)
        {
            //var filterdata = Builders<Country>.Filter.Eq(x => x.Name, countryName);
            //var country = _countries.Find(filterdata).FirstOrDefaultAsync();
            //return country
            return await _context.States.Where(x => x.StateName == stateName).ToListAsync();
        }



        public async Task<bool> UpdateState(State state)
        {
            try
            {
                _context.States.Update(state);
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
