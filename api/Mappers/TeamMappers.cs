using api.DTOs.Team;
using api.Models.User;

namespace api.Mappers;

public static class TeamMappers
{
    public static GetUserTeamsDTO toGetUserTeamsDTO(this Team teamModel)
    {
        return new GetUserTeamsDTO
        {
            Id = teamModel.Id,
            TeamName = teamModel.TeamName
        };
    }
}