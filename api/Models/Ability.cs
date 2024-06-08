using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Ability")]
    public class Ability
    {
        [Key]
        public int Id { get; set; }
        public string Identifier { get; set; } = "";
        public string FlavorText { get; set; } = "";

        public List<Pokemon> Pokemon { get; } = [];
    }
}