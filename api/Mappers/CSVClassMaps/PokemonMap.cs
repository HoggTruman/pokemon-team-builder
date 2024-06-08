using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PokemonMap : ClassMap<Pokemon>
    {
        public PokemonMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Identifier).Name("identifier");
            Map(m => m.SpeciesId).Name("species_id");
        }
    }
}

