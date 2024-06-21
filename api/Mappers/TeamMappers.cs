using api.DTOs.Team;
using api.DTOs.UserPokemon;
using api.Models.User;

namespace api.Mappers;

public static class TeamMappers
{
    public static GetUserTeamsDTO ToGetUserTeamsDTO(this Team teamModel)
    {
        return new GetUserTeamsDTO
        {
            Id = teamModel.Id,
            TeamName = teamModel.TeamName
        };
    }

    public static GetUserTeamDTO ToGetUserTeamDTO(this Team teamModel)
    {
        return new GetUserTeamDTO
        {
            Id = teamModel.Id,
            TeamName = teamModel.TeamName,
            UserPokemon = teamModel.UserPokemon
                .Select(x => x.ToUserPokemonDTO())
                .OrderBy(x => x.TeamSlot)
                .ToList()
                
        };
    }
}