using CountryAPI.Interfaces;
using CountryAPI.Model;

using CountryAPI.Utility.ApiResponse;

namespace CountryAPI.Services
{
    public class CityService : ICityService
    {
        
            private readonly ICityRepository _cityRepository;
           

            public CityService(ICityRepository cityRepository)
            {
               
                _cityRepository = cityRepository;
            }

            public async Task<ServiceResponse<List<City>>> GetCityByCityName(string cityname)
        {
                var result = await _cityRepository.GetCityByCityName(cityname);
                return BuildResponse.SuccessResponse(result, CityConstant.SuccessResponse);
            }

            public async Task<ServiceResponse<bool>> AddCity(City city)
            {
                var result = await _cityRepository.AddCity(city);
                return BuildResponse.SuccessResponse(result, CityConstant.AddResponse);
            }

            public async Task<ServiceResponse<bool>> UpdateCity(City city)
            {
                var result = await _cityRepository.UpdateCity(city);
                return BuildResponse.SuccessResponse(result, CityConstant.UpdateResponse);
            }

        
    }
}
