using api.Models.Static;

namespace api.Interfaces.Repository;

public interface IGenderRepository
{
    List<Gender> GetAll();
    Gender? GetById(int id);
}