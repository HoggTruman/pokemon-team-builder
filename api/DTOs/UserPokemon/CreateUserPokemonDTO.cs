using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.UserPokemon;

public class CreateUserPokemonDTO
{
    // public int TeamId { get; set; }

    [DefaultValue(1)]
    [Range(1, 6, ErrorMessage = "{0} must be between {1} and {2}")]
    public int TeamSlot { get; set; }

    [DefaultValue(null)]
    public int? PokemonId { get; set; }

    [DefaultValue(null)]
    public string? Nickname { get; set; }

    [DefaultValue(100)]
    [Range(1, 100, ErrorMessage = "{0} must be between {1} and {2}")]
    public int Level { get; set; } = 100;

    [DefaultValue(null)]
    public int? GenderId { get; set; }

    [DefaultValue(false)]
    public bool Shiny { get; set; }

    [DefaultValue(null)]
    public int? TeraPkmnTypeId { get; set; }

    [DefaultValue(null)]
    public int? ItemId { get; set; }

    [DefaultValue(null)]
    public int? AbilityId { get; set; }



    [DefaultValue(null)]
    public int? Move1Id { get; set; }

    [DefaultValue(null)]
    public int? Move2Id { get; set; }

    [DefaultValue(null)]
    public int? Move3Id { get; set; }

    [DefaultValue(null)]
    public int? Move4Id { get; set; }



    [DefaultValue(null)]
    public int? NatureId { get; set; }


    [DefaultValue(0)]
    [Range(0, 252, ErrorMessage = "{0} must be between {1} and {2}")]
    public int HPEV { get; set; }

    [DefaultValue(0)]
    [Range(0, 252, ErrorMessage = "{0} must be between {1} and {2}")]
    public int AttackEV { get; set; }

    [DefaultValue(0)]
    [Range(0, 252, ErrorMessage = "{0} must be between {1} and {2}")]
    public int DefenseEV { get; set; }

    [DefaultValue(0)]
    [Range(0, 252, ErrorMessage = "{0} must be between {1} and {2}")]
    public int SpecialAttackEV { get; set; }

    [DefaultValue(0)]
    [Range(0, 252, ErrorMessage = "{0} must be between {1} and {2}")]
    public int SpecialDefenseEV { get; set; }

    [DefaultValue(0)]
    [Range(0, 252, ErrorMessage = "{0} must be between {1} and {2}")]
    public int SpeedEV { get; set; }


    [DefaultValue(31)]
    [Range(0, 31, ErrorMessage = "{0} must be between {1} and {2}")]
    public int HPIV { get; set; } = 31;

    [DefaultValue(31)]
    [Range(0, 31, ErrorMessage = "{0} must be between {1} and {2}")]
    public int AttackIV { get; set; } = 31;

    [DefaultValue(31)]
    [Range(0, 31, ErrorMessage = "{0} must be between {1} and {2}")]
    public int DefenseIV { get; set; } = 31;

    [DefaultValue(31)]
    [Range(0, 31, ErrorMessage = "{0} must be between {1} and {2}")]
    public int SpecialAttackIV { get; set; } = 31;

    [DefaultValue(31)]
    [Range(0, 31, ErrorMessage = "{0} must be between {1} and {2}")]
    public int SpecialDefenseIV { get; set; } = 31;

    [DefaultValue(31)]
    [Range(0, 31, ErrorMessage = "{0} must be between {1} and {2}")]
    public int SpeedIV { get; set; } = 31;
}