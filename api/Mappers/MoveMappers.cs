using api.Models.Static;
using api.DTOs.Move;


namespace api.Mappers;

public static class MoveMappers
{
    public static GetMoveDTO ToMoveDTO(this Move moveModel)
    {
        return new GetMoveDTO
        {
        Identifier = moveModel.Identifier,
        Power = moveModel.Power,
        PP = moveModel.PP,
        Accuracy = moveModel.Accuracy, 
        Priority = moveModel.Priority,

        PkmnType  = moveModel.PkmnType.Identifier,

        DamageClass  = moveModel.DamageClass.Identifier,

        MoveEffect = moveModel.MoveEffect != null? moveModel.MoveEffect.Description: "",
        // THIS MAY BE WRONG TO HAVE AS AN INT, WHAT WILL NULL GET CONVERTED TO??????????????????????????????????????????????
        MoveEffectChance = moveModel.MoveEffectChance
        };
    }
} 
