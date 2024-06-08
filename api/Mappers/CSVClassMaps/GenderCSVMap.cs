using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class GenderCSVMap : ClassMap<Gender>
    {
        public GenderCSVMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Identifier).Name("identifier");
        }
    }
}

