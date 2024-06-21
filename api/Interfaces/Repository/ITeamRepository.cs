using api.DTOs.Team;
using api.Models.User;

namespace api.Interfaces.Repository;

public interface ITeamRepository
{
    List<Team>? GetTeamsByUserName(string userName);

    Team? GetTeamByUserNameAndId(string username, int id);

    Team? CreateTeam(CreateTeamDTO createTeamDTO);

    Team? UpdateTeamById(int id, UpdateTeamDTO updateTeamDTO);

    void DeleteTeamById(int id); // Will need to kill orphans left in UserPokemon
}