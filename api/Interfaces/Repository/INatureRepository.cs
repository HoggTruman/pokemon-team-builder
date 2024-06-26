using api.Models.Static;

namespace api.Interfaces.Repository;

public interface INatureRepository
{
    List<Nature> GetAll();
    Nature? GetById(int id);
}