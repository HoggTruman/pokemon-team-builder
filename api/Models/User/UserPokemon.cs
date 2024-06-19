using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.User;

[Table("UserPokemon")]
public class UserPokemon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    [ForeignKey("Team")]
    public int TeamId { get; set; }
    public Team Team { get; set; } = default!;

    public int TeamSlot { get; set; }


    [ForeignKey("Pokemon")]
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = default!;

    public string? Nickname { get; set; }

    public int Level { get; set; }

    [ForeignKey("Gender")]
    public int GenderId { get; set; }
    public Gender Gender { get; set; } = default!;

    public bool Shiny { get; set; }

    [ForeignKey("TeraPkmnType")]
    public int TeraPkmnTypeId { get; set; }
    public PkmnType TeraPkmnType { get; set; } = default!;


    [ForeignKey("Item")]
    public int? ItemId { get; set; }
    public Item? Item { get; set; }

    [ForeignKey("Ability")]
    public int AbilityId { get; set; }
    public Ability Ability { get; set; } = default!;


    [ForeignKey("Move1")]
    public int? Move1Id { get; set; }
    public Move? Move1 { get; set; }

    [ForeignKey("Move2")]
    public int? Move2Id { get; set; }
    public Move? Move2 { get; set; }

    [ForeignKey("Move3")]
    public int? Move3Id { get; set; }
    public Move? Move3 { get; set; }

    [ForeignKey("Move4")]
    public int? Move4Id { get; set; }
    public Move? Move4 { get; set; }


    [ForeignKey("Nature")]
    public int NatureId { get; set; }
    public Nature Nature { get; set; } = default!;


    public int HPEV { get; set; }
    public int AttackEV { get; set; }
    public int DefenseEV { get; set; }
    public int SpecialAttackEV { get; set; }
    public int SpecialDefenseEV { get; set; }
    public int SpeedEV { get; set; }


    public int HPIV { get; set; }
    public int AttackIV { get; set; }
    public int DefenseIV { get; set; }
    public int SpecialAttackIV { get; set; }
    public int SpecialDefenseIV { get; set; }
    public int SpeedIV { get; set; }
}   