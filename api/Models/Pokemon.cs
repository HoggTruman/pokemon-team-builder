using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Pokemon")]
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public required string Identifier { get; set; }
        public int SpeciesId { get; set; }


        // Navigation Variables (are both navigations needed everywhere??)
        public List<PkmnType> PkmnTypes { get; } = [];
        public List<PokemonPkmnType> PokemonPkmnTypes { get; } = [];

        public List<Gender> Genders { get; } = [];
        public List<PokemonGender> PokemonGenders { get; } = [];

        public List<Ability> Abilities { get; } = [];
        public List<PokemonAbility> PokemonAbilities { get; } = [];

        public BaseStats? BaseStats { get; set; }

    }
}