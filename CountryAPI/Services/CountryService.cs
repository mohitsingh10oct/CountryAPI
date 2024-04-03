using CountryAPI.Interfaces;
using CountryAPI.Model;
using CountryAPI.Repository;
using CountryAPI.Utility.ApiResponse;

namespace CountryAPI.Services
{
    public class Countrieservice : ICountrieservice
    {
        private readonly ICountryRepository _countryRepository;
        //private readonly ICountrieservice _countrieservice;

        public Countrieservice(ICountryRepository countryRepository/*, ICountrieservice countrieservice*/)
        {
            //_countrieservice = countrieservice;
            _countryRepository = countryRepository;   
        }


        //public async Task<ServiceResponse<Country>> GetCountryByCountryName(string countryname)
        //{
        //    var result = await _countryRepository.GetCountryByCountryName(countryname);
        //    return BuildResponse.SuccessResponse(result, CountryConstant.SuccessResponse);
        //}

        public async Task<ServiceResponse<List<Country>>> GetCountryByCountryName(string countryname)
        {
            var result = await _countryRepository.GetCountryByCountryName(countryname);
            return BuildResponse.SuccessResponse(result, CountryConstant.SuccessResponse);
        }

        public async Task<ServiceResponse<bool>> AddCountry(Country  country)
        {
            var result = await _countryRepository.AddCountry(country);
            return BuildResponse.SuccessResponse(result, CountryConstant.AddResponse);
        }

        public async Task<ServiceResponse<bool>> UpdateCountry(Country country)
        {
            var result = await _countryRepository.UpdateCountry(country);
            return BuildResponse.SuccessResponse(result, CountryConstant.UpdateResponse);
        }
    }
}
