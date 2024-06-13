using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models 
{
    [Table("PkmnType")]
    public class PkmnType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public required string Identifier { get; set; }

        public List<Pokemon> Pokemon { get; } = [];
    }
}