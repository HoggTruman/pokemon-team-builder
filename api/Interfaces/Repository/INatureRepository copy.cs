using api.Models.Static;

namespace api.Interfaces.Repository;

public interface IAbilityRepository
{
    List<Ability> GetAll();
    Ability? GetById(int id);
}