using api.Models;
using api.DTOs.PokemonAbility;


namespace api.Mappers;

public static class PokemonAbilityMappers
{
    public static PokemonAbilityDTO ToPokemonAbilityDTO(this PokemonAbility pokemonAbilityModel)
    {
        return new PokemonAbilityDTO
        {
            Identifier = pokemonAbilityModel.Ability.Identifier,
            FlavorText = pokemonAbilityModel.Ability.FlavorText,              
        };
    }
} 
