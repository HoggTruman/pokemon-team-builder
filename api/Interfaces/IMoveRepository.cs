using api.Models;

namespace api.Interfaces;

public interface IMoveRepository
{
    public List<Move> GetAll();
    public List<Move>? GetMovesByPokemonId(int id);
}