using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("PokemonMove")]
    public class PokemonMove
    {
        [ForeignKey("PokemonId")]
        public int PokemonId { get; set; }
        [ForeignKey("MoveId")]
        public int MoveId { get; set; }


        public Pokemon Pokemon { get; set; } = default!;
        public Move Move { get; set; } = default!;
    }
}