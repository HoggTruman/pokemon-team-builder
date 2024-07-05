using api.DTOs.Team;
using api.Models.User;

namespace api.Interfaces.Repository;

public interface ITeamRepository
{
    List<Team> GetTeams(string userId);

    Team? GetTeamById(int id, string userId);

    Team CreateTeam(CreateUpdateTeamDTO createTeamDTO, string userId);

    Team? UpdateTeam(CreateUpdateTeamDTO updateTeamDTO, int id, string userId);

    Team? DeleteTeamById(int id, string userId);
}