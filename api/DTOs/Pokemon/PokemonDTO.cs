using System.Text.Json.Serialization;
using api.DTOs.PokemonAbility;

namespace api.DTOs.Pokemon
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string? Identifier { get; set; }
        public int SpeciesId { get; set; }

        public List<string> PkmnTypes { get; set; } = [];
        [JsonPropertyName("abilities")]
        public List<PokemonAbilityDTO> PokemonAbilities { get; set; } = [];

        public Dictionary<string, int> BaseStats { get; set; } = [];

    }
}