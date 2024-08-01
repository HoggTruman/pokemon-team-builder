using api.DTOs.Team;
using api.DTOs.UserPokemon;
using api.Models.User;

namespace api.Mappers;

public static class TeamMappers
{
    public static GetTeamDTO ToGetTeamDTO(this Team teamModel)
    {
        return new GetTeamDTO
        {
            Id = teamModel.Id,
            TeamName = teamModel.TeamName,
            UserPokemon = teamModel.UserPokemon
                .Select(x => x.ToGetUserPokemonDTO())
                .OrderBy(x => x.TeamSlot)
                .ToList()
                
        };
    }
}