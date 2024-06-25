using api.Models.Static;
using api.DTOs.Pokemon;


namespace api.Mappers;

public static class PokemonMappers
{
    public static PokemonDTO ToPokemonDTO(this Pokemon pokemonModel)
    {
        return new PokemonDTO
        {
            Id = pokemonModel.Id,
            Identifier = pokemonModel.Identifier,
            SpeciesId = pokemonModel.SpeciesId,

            PokemonPkmnTypes = pokemonModel.PokemonPkmnTypes
                .OrderBy(x => x.Slot)
                .Select(x => x.PkmnType.Identifier)
                .ToList(),

            PokemonGenders = pokemonModel.Genders
                .Select(x => x.Identifier)
                .Order()
                .ToList(),

            PokemonAbilities = pokemonModel.PokemonAbilities
                .OrderBy(x => x.Slot)
                .Select(x => x.ToPokemonAbilityDTO())
                .ToList(),

            BaseStats = pokemonModel.BaseStats.ToBaseStatsDTO() 
        };
    }
} 
