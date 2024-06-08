using api.Models;
using api.DTOs.PokemonAbility;


namespace api.Mappers;

public static class PokemonAbilityMappers
{
    public static PokemonAbilityDTO ToPokemonAbilityDTO(this PokemonAbility pokemonAbilityModel)
    {
        return new PokemonAbilityDTO
        {
            Id = pokemonAbilityModel.Ability.Id,
            Identifier = pokemonAbilityModel.Ability.Identifier,
            FlavorText = pokemonAbilityModel.Ability.FlavorText,
            Slot = pokemonAbilityModel.Slot                 
        };
    }
} 
