using api.Models;
namespace api.Interfaces;

public interface IPokemonRepository
{
    List<Pokemon> GetAllPokemon();
    Pokemon? GetPokemonById(int id);
}