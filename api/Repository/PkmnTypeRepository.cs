using api.Data;
using api.Interfaces.Repository;
using api.Models.Static;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class PkmnTypeRepository : IPkmnTypeRepository
{
    private readonly ApplicationDbContext _context;
    public PkmnTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<PkmnType> GetAll()
    {
        var pkmnTypes = _context.PkmnType
            .AsNoTracking()
            .ToList();

        return pkmnTypes;
    }

    public PkmnType? GetById(int id)
    {
        var pkmnType = _context.PkmnType
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        return pkmnType;
    }
}