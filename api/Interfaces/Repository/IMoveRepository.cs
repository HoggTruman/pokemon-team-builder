using api.Models.Static;

namespace api.Interfaces.Repository;

public interface IMoveRepository
{
    List<Move> GetAll();
    List<Move>? GetMovesByPokemonId(int id);
}