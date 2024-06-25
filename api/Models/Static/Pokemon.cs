using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Static;

[Table("Pokemon")]
public class Pokemon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public required string Identifier { get; set; }
    public int SpeciesId { get; set; }


    public List<PkmnType> PkmnTypes { get; } = [];
    public List<PokemonPkmnType> PokemonPkmnTypes { get; } = [];

    public List<Gender> Genders { get; } = [];

    public List<Ability> Abilities { get; } = [];
    public List<PokemonAbility> PokemonAbilities { get; } = [];

    public BaseStats BaseStats { get; set; } = default!;

    public List<Move> Moves { get; } = [];

}
