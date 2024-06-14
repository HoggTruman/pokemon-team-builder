using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PokemonPkmnTypeCSVMap : ClassMap<PokemonPkmnType>
    {
        public PokemonPkmnTypeCSVMap()
        {
            Map(m => m.PokemonId).Index(0).Name("pokemon_id");
            Map(m => m.PkmnTypeId).Index(1).Name("type_id");
            Map(m => m.Slot).Index(2).Name("slot");
        }
    }
}

