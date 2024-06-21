using api.Interfaces.Repository;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/type")]
[ApiController]
public class PkmnTypeController : ControllerBase
{
    private readonly IPkmnTypeRepository _repository;

    public PkmnTypeController(IPkmnTypeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pkmnTypes = _repository.GetAll().Select(x => x.ToPkmnTypeDTO());

        return Ok(pkmnTypes);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var pkmnType = _repository.GetById(id);

        if (pkmnType == null)
        {
            return NotFound();
        }

        return Ok(pkmnType.ToPkmnTypeDTO());
    }
    
}