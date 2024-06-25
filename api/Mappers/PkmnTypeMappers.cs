using api.Models.Static;
using api.DTOs.PkmnType;


namespace api.Mappers;

public static class PkmnTypeMappers
{
    public static PkmnTypeDTO ToPkmnTypeDTO(this PkmnType pkmnTypeModel)
    {
        return new PkmnTypeDTO
        {
            Id = pkmnTypeModel.Id,
            Identifier = pkmnTypeModel.Identifier   
        };
    }
} 
