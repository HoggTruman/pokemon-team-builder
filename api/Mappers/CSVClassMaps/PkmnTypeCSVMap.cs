using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PkmnTypeCSVMap : ClassMap<PkmnType>
    {
        public PkmnTypeCSVMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Identifier).Name("identifier");
        }
    }
}

