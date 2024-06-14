using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class AbilityCSVMap : ClassMap<Ability>
    {
        public AbilityCSVMap()
        {
            Map(m => m.Id).Index(0).Name("id");
            Map(m => m.Identifier).Index(1).Name("identifier");
        }
    }
}

