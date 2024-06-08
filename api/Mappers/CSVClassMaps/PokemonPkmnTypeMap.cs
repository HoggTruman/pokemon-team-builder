using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PokemonPkmnTypeMap : ClassMap<PokemonPkmnType>
    {
        public PokemonPkmnTypeMap()
        {
            Map(m => m.PokemonId).Name("pokemon_id");
            Map(m => m.PkmnTypeId).Name("type_id");
            Map(m => m.Slot).Name("slot");
        }
    }
}

