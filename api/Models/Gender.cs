using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models 
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Identifier { get; set; } = "";

        public List<Pokemon> Pokemon { get; set; } = [];
        public List<PokemonGender> PokemonGenders = [];
    }
}