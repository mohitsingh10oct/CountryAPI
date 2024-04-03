using CountryAPI.Interfaces;
using CountryAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _CityService;
        
        public CityController(ICityService CityService )
        {
          
            _CityService = CityService;
        }

        [HttpGet("healthcheck")]
        public async Task<string> HealthCheck()
        {
            return await Task.FromResult<string>("Kitchen api is available...");
        }

        [HttpGet]
        public async Task<IActionResult> CityName(string cityName)
        {
            if (ModelState.IsValid)
            {
                var result = await _CityService.GetCityByCityName(cityName);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddCity(City city)
        {
            if (ModelState.IsValid)
            {
                var result = await _CityService.AddCity(city);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(City city)
        {
            if (ModelState.IsValid)
            {
                var result = await _CityService.UpdateCity(city);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
