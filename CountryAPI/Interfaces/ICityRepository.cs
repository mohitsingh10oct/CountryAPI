using CountryAPI.Model;

namespace CountryAPI.Interfaces
{
    public interface ICityRepository
    {

        Task<List<City>> GetCityByCityName(string cityName);
        

        Task<bool> AddCity(City city);
        Task<bool> UpdateCity(City city);
    }
}
