using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PokemonMoveCSVMap : ClassMap<PokemonMove>
    {
        public PokemonMoveCSVMap()
        {
            Map(m => m.PokemonId).Name("pokemon_id");
            Map(m => m.MoveId).Name("move_id");
        }
    }
}