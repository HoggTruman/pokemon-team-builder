using api.Data;
using api.Interfaces.Repository;
using api.Models.Static;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class ItemRepository : IItemRepository
{
    private readonly ApplicationDbContext _context;
    
    public ItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Item> GetAll()
    {
        var items = _context.Item
            .AsNoTracking()
            .ToList();

        return items;
    }

    public Item? GetById(int id)
    {
        var item = _context.Item
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        return item;
    }
}