using api.Models.Static;
using api.DTOs.Ability;


namespace api.Mappers;

public static class AbilityMappers
{
    public static AbilityDTO ToAbilityDTO(this Ability abilityModel)
    {
        return new AbilityDTO
        {
            Id = abilityModel.Id,
            Identifier = abilityModel.Identifier,
            FlavorText = abilityModel.FlavorText   
        };
    }
} 
