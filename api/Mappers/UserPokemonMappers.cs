using api.DTOs.UserPokemon;
using api.DTOS.Misc;
using api.Models.User;

namespace api.Mappers;

public static class UserPokemonMappers
{
    public static UserPokemonDTO ToUserPokemonDTO(this UserPokemon userPokemonModel)
    {
        return new UserPokemonDTO
        {
            Id = userPokemonModel.Id,
            TeamId = userPokemonModel.TeamId,
            TeamSlot = userPokemonModel.TeamSlot,
            PokemonId = userPokemonModel.PokemonId,
            Nickname = userPokemonModel.Nickname,
            Level = userPokemonModel.Level,
            GenderId = userPokemonModel.GenderId,
            Shiny = userPokemonModel.Shiny,
            TeraPkmnTypeId = userPokemonModel.TeraPkmnTypeId,
            ItemId = userPokemonModel.ItemId,
            AbilityId = userPokemonModel.AbilityId,

            Moves = new List<int?>
            {
                userPokemonModel.Move1Id,
                userPokemonModel.Move2Id,
                userPokemonModel.Move3Id,
                userPokemonModel.Move4Id,
            },

            NatureId = userPokemonModel.NatureId,

            EV = new EffortValuesDTO
            {
                HP = userPokemonModel.HPEV,
                Attack = userPokemonModel.AttackEV,
                Defense = userPokemonModel.DefenseEV,
                SpecialAttack = userPokemonModel.SpecialAttackEV,
                SpecialDefense = userPokemonModel.SpecialDefenseEV,
                Speed = userPokemonModel.SpeedEV
            },

            IV = new IndividualValuesDTO
            {
                HP = userPokemonModel.HPIV,
                Attack = userPokemonModel.AttackIV,
                Defense = userPokemonModel.DefenseIV,
                SpecialAttack = userPokemonModel.SpecialAttackIV,
                SpecialDefense = userPokemonModel.SpecialDefenseIV,
                Speed = userPokemonModel.SpeedIV
            }
        };
    }
}
