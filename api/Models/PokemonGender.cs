using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models 
{
    [Table("PokemonGender")]
    public class PokemonGender
    {
        [ForeignKey("PokemonId")]
        public int PokemonId { get; set; }
        [ForeignKey("GenderId")]
        public int GenderId { get; set; }

        public Pokemon? Pokemon { get; set; }
        public Gender? Gender { get; set; }
    }
}