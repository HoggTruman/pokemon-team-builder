using api.Models;

namespace api.Interfaces.Repository;

public interface INatureRepository
{
    public List<Nature> GetAll();
}