using api.Data;
using api.Interfaces.Repository;
using api.Models.Static;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class NatureRepository : INatureRepository
{
    private readonly ApplicationDbContext _context;
    
    public NatureRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Nature> GetAll()
    {
        var natures = _context.Nature
            .AsNoTracking()
            .ToList();

        return natures;
    }
}