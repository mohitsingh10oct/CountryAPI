using CountryAPI.Model;
using CountryAPI.Services;
using CountryAPI.Utility.ApiResponse;

namespace CountryAPI.Interfaces
{
    public interface ICountrieservice
    {
        Task<ServiceResponse<List<Country>>> GetCountryByCountryName(string name);
        //Task<ServiceResponse<Country>> GetCountryByCountryName(string name);
        Task<ServiceResponse<bool>> AddCountry(Country country);

        Task<ServiceResponse<bool>> UpdateCountry(Country country);
    }
}
