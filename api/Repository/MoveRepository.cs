using api.Data;
using api.Models;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Interfaces;

public class MoveRepository : IMoveRepository
{
    private readonly ApplicationDbContext _context;

    public MoveRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Move> GetAll()
    {
        var moves = _context.Move
            .Include(x => x.PkmnType)
            .Include(x => x.DamageClass)
            .Include(x => x.MoveEffect)
            .AsNoTracking()
            .ToList();

        return moves;
    }

    public List<Move>? GetMovesByPokemonId(int pokemonId)
    {
        var pokemon = _context.Pokemon
            .Include(x => x.Moves)
                .ThenInclude(x => x.PkmnType)
            .Include(x => x.Moves)
                .ThenInclude(x => x.DamageClass)
            .Include(x => x.Moves)
                .ThenInclude(x => x.MoveEffect)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == pokemonId);

        if (pokemon == null)
        {
            return null;
        }

        var moves = pokemon.Moves;
            // .Include(x => x.PkmnType)
            // .Include(x => x.DamageClass)
            // .Include(x => x.MoveEffect))
            // .ToList();

        // var moves = _context.Move
        //     .Include(x => x.PkmnType)
        //     .Include(x => x.DamageClass)
        //     .Include(x => x.MoveEffect)    
        //     .Include(x => x.Pokemon)
        //     .Where(x => x.Pokemon.Any(x => x.Id == id))
        //     .ToList();


        return moves;
    }
}