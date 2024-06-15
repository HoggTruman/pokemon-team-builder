using api.Data;
using api.Models;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Interfaces;

public class PokemonRepository : IPokemonRepository
{
    private readonly ApplicationDbContext _context;

    public PokemonRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public List<Pokemon> GetAllPokemon()
    {
        var pokemon = _context.Pokemon
            .Include(x => x.PokemonPkmnTypes)
                .ThenInclude(x => x.PkmnType)
            .Include(x => x.BaseStats)
            .Include(x => x.PokemonAbilities)
                .ThenInclude(x => x.Ability)
            .Include(x => x.Genders)
            .AsNoTracking()
            .ToList();

        return pokemon;
    }

    public Pokemon? GetPokemonById(int id)
    {
        var pokemon = _context.Pokemon
            .Include(x => x.PokemonPkmnTypes)
                .ThenInclude(x => x.PkmnType)
            .Include(x => x.BaseStats)
            .Include(x => x.PokemonAbilities)
                .ThenInclude(x => x.Ability)
            .Include(x => x.Genders)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        return pokemon;
    }
}