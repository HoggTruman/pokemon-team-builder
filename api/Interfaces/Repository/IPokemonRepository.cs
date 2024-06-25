using api.Models.Static;
namespace api.Interfaces.Repository;

public interface IPokemonRepository
{
    List<Pokemon> GetAllPokemon();
    Pokemon? GetPokemonById(int id);
}