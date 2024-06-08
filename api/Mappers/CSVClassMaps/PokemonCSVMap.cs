using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PokemonCSVMap : ClassMap<Pokemon>
    {
        public PokemonCSVMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Identifier).Name("identifier");
            Map(m => m.SpeciesId).Name("species_id");
        }
    }
}

