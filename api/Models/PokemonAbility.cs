using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("PokemonAbility")]
public class PokemonAbility
{
    [ForeignKey("PokemonId")]
    public int PokemonId { get; set; }
    [ForeignKey("AbilityId")]
    public int AbilityId { get; set; }
    
    public int Slot { get; set; }

    public Pokemon? Pokemon { get; set; }
    public Ability? Ability { get; set; }
}