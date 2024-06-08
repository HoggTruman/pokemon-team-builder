using api.Models;
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

            PokemonGenders = pokemonModel.PokemonGenders
                .Select(x => x.Gender.Identifier)
                .Order()
                .ToList(),

            PokemonAbilities = pokemonModel.PokemonAbilities
                .OrderBy(x => x.Slot)
                .Select(x => x.ToPokemonAbilityDTO())
                .ToList(),

            BaseStats = new Dictionary<string, int>()
            {
                { "HP", pokemonModel.BaseStats.HP },
                { "Attack", pokemonModel.BaseStats.Attack },
                { "Defense", pokemonModel.BaseStats.Defense },
                { "SpecialAttack", pokemonModel.BaseStats.SpecialAttack },
                { "SpecialDefense", pokemonModel.BaseStats.SpecialDefense },
                { "Speed", pokemonModel.BaseStats.Speed }
            }

                            
        };
    }
} 
