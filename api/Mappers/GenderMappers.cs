using api.DTOs.Gender;
using api.Models.Static;

namespace api.Mappers;

public static class GenderMappers
{
    public static GenderDTO ToGenderDTO(this Gender genderModel)
    {
        return new GenderDTO
        {
            Id = genderModel.Id,
            Identifier = genderModel.Identifier,
        };
    }
}