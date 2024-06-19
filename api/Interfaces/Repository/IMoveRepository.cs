using api.Models;

namespace api.Interfaces.Repository;

public interface IMoveRepository
{
    public List<Move> GetAll();
    public List<Move>? GetMovesByPokemonId(int id);
}