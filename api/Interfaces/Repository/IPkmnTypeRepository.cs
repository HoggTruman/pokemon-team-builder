using api.Models.Static;

namespace api.Interfaces.Repository;

public interface IPkmnTypeRepository
{
    List<PkmnType> GetAll();
    PkmnType? GetById(int id);
}