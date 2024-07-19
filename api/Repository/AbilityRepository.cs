using api.Data;
using api.Interfaces.Repository;
using api.Models.Static;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class AbilityRepository : IAbilityRepository
{
    private readonly ApplicationDbContext _context;
    
    public AbilityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Ability> GetAll()
    {
        var abilities = _context.Ability
            .AsNoTracking()
            .ToList();

        return abilities;
    }

    public Ability? GetById(int id)
    {
        var ability = _context.Ability
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        return ability;
    }
}