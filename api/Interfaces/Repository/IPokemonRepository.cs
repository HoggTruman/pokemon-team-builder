using api.Models.Static;
namespace api.Interfaces.Repository;

public interface IPokemonRepository
{
    List<Pokemon> GetAll();
    Pokemon? GetById(int id);
}