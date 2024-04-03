using CountryAPI.Model;

namespace CountryAPI.Interfaces
{
    public interface IStateRepository
    {
        Task<List<State>> GetStateByStateName(string stateName);


        Task<bool> AddState(State state);
        Task<bool> UpdateState(State state);
    }
}
