using System.Text.Json.Serialization;

namespace api.DTOs.BaseStats
{
    public class BaseStatsDTO
    {
        [JsonPropertyName("HP")]
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
    }
}