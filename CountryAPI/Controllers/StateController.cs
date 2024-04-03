using CountryAPI.Interfaces;
using CountryAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _StateService;

        public StateController(IStateService StateService)
        {

            _StateService = StateService;
        }

        [HttpGet("healthcheck")]
        public async Task<string> HealthCheck()
        {
            return await Task.FromResult<string>("Kitchen api is available...");
        }

        [HttpGet]
        public async Task<IActionResult> StateName(string stateName)
        {
            if (ModelState.IsValid)
            {
                var result = await _StateService.GetStateByStateName(stateName);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddState(State state)
        {
            if (ModelState.IsValid)
            {
                var result = await _StateService.AddState(state);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateState(State state)
        {
            if (ModelState.IsValid)
            {
                var result = await _StateService.UpdateState(state);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
