using api.Interfaces.Repository;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/item")]
[ApiController]
public class ItemController : ControllerBase
{
    IItemRepository _repository;

    public ItemController(IItemRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var items = _repository.GetAll().Select(x => x.ToItemDTO());

        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var item = _repository.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item.ToItemDTO());
    }

}