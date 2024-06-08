using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("PokemonPkmnType")]
    public class PokemonPkmnType
    {
        public int PokemonId { get; set; }
        public int PkmnTypeId { get; set; }
        
        public int Slot { get; set; }

        public Pokemon Pokemon { get; set; } = default!;
        public PkmnType PkmnType { get; set; } = default!;
    }
}