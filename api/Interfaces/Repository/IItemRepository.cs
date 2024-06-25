using api.Models.Static;

namespace api.Interfaces.Repository;

public interface IItemRepository
{
    List<Item> GetAll();
    Item? GetById(int id);
}