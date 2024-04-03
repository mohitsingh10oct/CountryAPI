using CountryAPI.Model;
using CountryAPI.Utility.ApiResponse;

namespace CountryAPI.Interfaces
{
    public interface ICityService
    {
        Task<ServiceResponse<List<City>>> GetCityByCityName(string name);
       
        Task<ServiceResponse<bool>> AddCity(City city);

        Task<ServiceResponse<bool>> UpdateCity(City city);
    }
}
