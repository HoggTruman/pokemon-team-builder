using System.Security.Claims;
using api.Interfaces.Repository;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("team")]
public class TeamController : ControllerBase
{
    private readonly ITeamRepository _repository;

    public TeamController(ITeamRepository repository)
    {
        _repository = repository;
    }


    [HttpGet]
    [Authorize]
    public IActionResult GetUserTeams()
    {
        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;

        var teams = _repository.GetTeamsByUserName(userName);

        if (teams == null)
        {
            return NotFound();
        }
            

        return Ok(teams.Select(x => x.ToGetUserTeamsDTO()));
    }


    [HttpGet("{id:int}")]
    [Authorize]
    public IActionResult GetUserTeamById([FromRoute] int id)
    {
        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;

        var team = _repository.GetTeamByUserNameAndId(userName, id);

        if (team == null)
        {
            return NotFound();
        }

        return Ok(team.ToGetUserTeamDTO());
    }
}