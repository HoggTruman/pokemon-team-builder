using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Move")]
    public class Move
    {
        [Key]
        public int Id { get; set; }
        public string Identifier { get; set; } = "";
        public int? Power { get; set; }
        [Column("pp")]
        public int? PP { get; set; }
        public int? Accuracy { get; set; }
        public int Priority { get; set; }

        [ForeignKey("PkmnTypeId")]
        public int PkmnTypeId { get; set; }
        [ForeignKey("DamageClassId")]
        public int DamageClassId { get; set; }

        [ForeignKey("MoveEffectId")]
        public int? MoveEffectId { get; set; }
        public int? MoveEffectChance { get; set; }


        public PkmnType PkmnType { get; set; } = default!;
        public DamageClass DamageClass { get; set; } = default!;
        public MoveEffect? MoveEffect { get; set; }
    }
}