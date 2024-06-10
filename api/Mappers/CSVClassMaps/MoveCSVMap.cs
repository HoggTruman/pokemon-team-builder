using api.Models;
using CsvHelper.Configuration;

namespace api.Mappers.CSVClassMaps
{
    public class MoveCSVMap: ClassMap<Move>
    {
        public MoveCSVMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Identifier).Name("identifier");
            Map(m => m.Power).Name("power");
            Map(m => m.PP).Name("pp");
            Map(m => m.Accuracy).Name("accuracy");
            Map(m => m.Priority).Name("priority");
            Map(m => m.PkmnTypeId).Name("type_id");
            Map(m => m.DamageClassId).Name("damage_class_id");
            Map(m => m.MoveEffectId).Name("effect_id");
            Map(m => m.MoveEffectChance).Name("effect_chance");
        }
    }
}