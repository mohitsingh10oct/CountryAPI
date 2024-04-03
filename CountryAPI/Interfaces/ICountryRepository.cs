using CountryAPI.Model;

namespace CountryAPI.Interfaces
{
    public interface ICountryRepository
    {

        Task<List<Country>> GetCountryByCountryName(string countryName);
        //Task<Country> GetCountryByCountryName(string countryName);

        Task<bool> AddCountry(Country country);
        Task<bool> UpdateCountry(Country country);
    }
}
