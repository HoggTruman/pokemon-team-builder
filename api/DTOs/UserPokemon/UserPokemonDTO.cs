using System.ComponentModel.DataAnnotations;
using api.DTOS.Misc;

namespace api.DTOs.UserPokemon;

public class UserPokemonDTO
{
    public int Id { get; set; }

    public int TeamId { get; set; }

    [Range(1, 6, ErrorMessage = "{0} must be between {1} and {2}")]
    public int TeamSlot { get; set; }

    public int PokemonId { get; set; }

    public string? Nickname { get; set; }

    [Range(1, 100, ErrorMessage = "{0} must be between {1} and {2}")]
    public int Level { get; set; }

    public int GenderId { get; set; }

    public bool Shiny { get; set; }

    public int TeraPkmnTypeId { get; set; }

    public int? ItemId { get; set; }

    public int AbilityId { get; set; }

    [MaxLength(4, ErrorMessage = "Can not have more than {1} moves")]
    public required List<int?> Moves { get; set; }

    public int NatureId { get; set; }

    public required EffortValuesDTO EV { get; set; }
    public required IndividualValuesDTO IV { get; set; }
}