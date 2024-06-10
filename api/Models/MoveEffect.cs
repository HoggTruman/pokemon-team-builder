using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("MoveEffect")]
    public class MoveEffect
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = "";


        public List<Move> Moves { get; } = [];        
    }
}