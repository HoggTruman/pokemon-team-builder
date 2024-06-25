using api.Models.Static;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class GenderCSVMap : ClassMap<Gender>
    {
        public GenderCSVMap()
        {
            Map(m => m.Id).Index(0).Name("id");
            Map(m => m.Identifier).Index(1).Name("identifier");
        }
    }
}

