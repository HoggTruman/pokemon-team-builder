using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PokemonAbilityMap : ClassMap<PokemonAbility>
    {
        public PokemonAbilityMap()
        {
            Map(m => m.PokemonId).Name("pokemon_id");
            Map(m => m.AbilityId).Name("ability_id");
            Map(m => m.Slot).Name("slot");
        }
    }
}

