using api.Models.Static;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class PkmnTypeCSVMap : ClassMap<PkmnType>
    {
        public PkmnTypeCSVMap()
        {
            Map(m => m.Id).Index(0).Name("id");
            Map(m => m.Identifier).Index(1).Name("identifier");
        }
    }
}

