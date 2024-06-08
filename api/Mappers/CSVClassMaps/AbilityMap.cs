using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class AbilityMap : ClassMap<Ability>
    {
        public AbilityMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Identifier).Name("identifier");
        }
    }
}

