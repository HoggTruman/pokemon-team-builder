using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class GenderMap : ClassMap<Gender>
    {
        public GenderMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Identifier).Name("identifier");
        }
    }
}

