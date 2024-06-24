using api.DTOs.UserPokemon;
using api.DTOS.Misc;
using api.Models.User;

namespace api.Mappers;

public static class UserPokemonMappers
{
    public static GetUserPokemonDTO ToGetUserPokemonDTO(this UserPokemon userPokemonModel)
    {
        return new GetUserPokemonDTO
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

    public static UserPokemon ToUserPokemon(this CreateUserPokemonDTO createUserPokemonDTO)
    {
        return new UserPokemon
        {
            // TeamId = createUserPokemonDTO.TeamId,
            TeamSlot = createUserPokemonDTO.TeamSlot,
            PokemonId = createUserPokemonDTO.PokemonId,
            Nickname = createUserPokemonDTO.Nickname,
            Level = createUserPokemonDTO.Level,
            GenderId = createUserPokemonDTO.GenderId,
            Shiny = createUserPokemonDTO.Shiny,
            TeraPkmnTypeId = createUserPokemonDTO.TeraPkmnTypeId,
            ItemId = createUserPokemonDTO.ItemId,
            AbilityId = createUserPokemonDTO.AbilityId,

            Move1Id = createUserPokemonDTO.Move1Id,
            Move2Id = createUserPokemonDTO.Move2Id,
            Move3Id = createUserPokemonDTO.Move3Id,
            Move4Id = createUserPokemonDTO.Move4Id,

            NatureId = createUserPokemonDTO.NatureId,

            HPEV = createUserPokemonDTO.HPEV,
            AttackEV = createUserPokemonDTO.AttackEV,
            DefenseEV = createUserPokemonDTO.DefenseEV,
            SpecialAttackEV = createUserPokemonDTO.SpecialAttackEV,
            SpecialDefenseEV = createUserPokemonDTO.SpecialDefenseEV,
            SpeedEV = createUserPokemonDTO.SpeedEV,

            HPIV = createUserPokemonDTO.HPIV,
            AttackIV = createUserPokemonDTO.AttackIV,
            DefenseIV = createUserPokemonDTO.DefenseIV,
            SpecialAttackIV = createUserPokemonDTO.SpecialAttackIV,
            SpecialDefenseIV = createUserPokemonDTO.SpecialDefenseIV,
            SpeedIV = createUserPokemonDTO.SpeedIV,
        };
    }
}
