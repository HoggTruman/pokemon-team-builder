using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PkmnTypeMap : ClassMap<PkmnType>
    {
        public PkmnTypeMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Identifier).Name("identifier");
        }
    }
}

