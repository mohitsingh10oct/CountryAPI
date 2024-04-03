using CountryAPI.Model;
using CountryAPI.Utility.ApiResponse;

namespace CountryAPI.Interfaces
{
    public interface IStateService
    {
        Task<ServiceResponse<List<State>>> GetStateByStateName(string name);

        Task<ServiceResponse<bool>> AddState(State state);

        Task<ServiceResponse<bool>> UpdateState(State state);
    }
}
