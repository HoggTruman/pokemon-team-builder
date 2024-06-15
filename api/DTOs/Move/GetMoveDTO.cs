using System.Text.Json.Serialization;

namespace api.DTOs.Move
{
    public class GetMoveDTO
    {
        public string Identifier { get; set; } = "";
        public int? Power { get; set; }
        [JsonPropertyName("pp")]
        public int? PP { get; set; }
        public int? Accuracy { get; set; }
        public int Priority { get; set; }

        [JsonPropertyName("Type")]
        public string PkmnType { get; set; } = "";

        public string DamageClass { get; set; } = "";

        public string MoveEffect { get; set; } = "";
        public int? MoveEffectChance { get; set; }
    }
}