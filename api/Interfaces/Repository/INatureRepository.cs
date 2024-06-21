using api.Models;

namespace api.Interfaces.Repository;

public interface INatureRepository
{
    List<Nature> GetAll();
}