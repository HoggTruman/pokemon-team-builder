using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class MoveEffectCSVMap : ClassMap<MoveEffect>
    {
        public MoveEffectCSVMap()
        {
            Map(m => m.Id).Name("move_effect_id");
            Map(m => m.Description).Name("short_effect");
        }
    }
}

