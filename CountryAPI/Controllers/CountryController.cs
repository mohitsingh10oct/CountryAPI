using CountryAPI.Interfaces;
using CountryAPI.Model;

using Microsoft.AspNetCore.Mvc;

namespace CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountrieservice _CountryService;
        //private readonly  ICountryRepository _countryRepository;
        public CountryController(ICountrieservice CountryService /*ICountryRepository countryRepository*/)
        {
            //_countryRepository = countryRepository;
            _CountryService = CountryService;
        }

        [HttpGet("healthcheck")]
        public async Task<string> HealthCheck()
        {
            return await Task.FromResult<string>("Kitchen api is available...");
        }

        [HttpGet]
        public async Task<IActionResult> BranchName(string branchName)
        {
            if (ModelState.IsValid)
            {
                var result = await _CountryService.GetCountryByCountryName(branchName);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                var result = await _CountryService.AddCountry(country);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                 var result = await _CountryService.UpdateCountry(country);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
