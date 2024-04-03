using CountryAPI.Interfaces;
using CountryAPI.Model;
using CountryAPI.Utility.ApiResponse;

namespace CountryAPI.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;


        public StateService(IStateRepository stateRepository)
        {

            _stateRepository = stateRepository;
        }

        public async Task<ServiceResponse<List<State>>> GetStateByStateName(string statename)
        {
            var result = await _stateRepository.GetStateByStateName(statename);
            return BuildResponse.SuccessResponse(result, StateConstant.SuccessResponse);
        }

        public async Task<ServiceResponse<bool>> AddState(State state)
        {
            var result = await _stateRepository.AddState(state);
            return BuildResponse.SuccessResponse(result, StateConstant.AddResponse);
        }

        public async Task<ServiceResponse<bool>> UpdateState(State state)
        {
            var result = await _stateRepository.UpdateState(state);
            return BuildResponse.SuccessResponse(result, StateConstant.UpdateResponse);
        }
    }
}
