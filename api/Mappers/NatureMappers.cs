using api.Models.Static;
using api.DTOs.Nature;


namespace api.Mappers;

public static class NatureMappers
{
    public static NatureDTO ToNatureDTO(this Nature natureModel)
    {
        return new NatureDTO
        {
            Identifier = natureModel.Identifier,
            AttackMultiplier = natureModel.AttackMultiplier,
            DefenseMultiplier = natureModel.DefenseMultiplier,
            SpecialAttackMultiplier = natureModel.SpecialAttackMultiplier,
            SpecialDefenseMultiplier = natureModel.SpecialDefenseMultiplier,
            SpeedMultiplier = natureModel.SpeedMultiplier           
        };
    }
} 
