using System.ComponentModel.DataAnnotations;
using api.DTOs.UserPokemon;

namespace api.DTOs.Team;

public class CreateTeamDTO
{
    public string TeamName { get; set; } = "";

    // [MinLength(6, ErrorMessage = "A team must have 6 pokemon")]
    [MaxLength(6, ErrorMessage = "A team must have 6 pokemon")]
    public List<CreateUserPokemonDTO> UserPokemon { get; set; } = [];
}