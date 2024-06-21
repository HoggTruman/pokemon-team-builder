using api.Interfaces.Repository;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class TeamController : ControllerBase
{
    private readonly ITeamRepository _repository;

    public TeamController(ITeamRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("{userName}")]
    public IActionResult GetAllByUserName([FromRoute] string userName)
    {
        var teams = _repository.GetAllByUserName(userName);

        if (teams == null)
        {
            return NotFound();
        }
            

        return Ok(teams.Select(x => x.toGetUserTeamsDTO()));
    }
}