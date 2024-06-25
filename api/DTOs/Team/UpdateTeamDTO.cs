using System.ComponentModel.DataAnnotations;
using api.DTOs.UserPokemon;


namespace api.DTOs.Team;

public class UpdateTeamDTO
{
    public int Id { get; set; }
    public string TeamName { get; set; } = "";

    [MaxLength(6, ErrorMessage = "A team can not have more than 6 pokemon")]
    public List<CreateUserPokemonDTO> UserPokemon { get; set; } = [];
}