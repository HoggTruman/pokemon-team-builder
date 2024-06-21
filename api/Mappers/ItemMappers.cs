using api.DTOs.Item;
using api.Models;

namespace api.Mappers;

public static class ItemMappers
{
    public static ItemDTO ToItemDTO(this Item itemModel)
    {
        return new ItemDTO
        {
            Id = itemModel.Id,
            Identifier = itemModel.Identifier,
            Effect = itemModel.Effect
        };
    }
}