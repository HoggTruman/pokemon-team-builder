using System.Security.Claims;
using api.DTOs.Team;
using api.Interfaces.Repository;
using api.Mappers;
using api.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("team")]
public class TeamController : ControllerBase
{
    private readonly ITeamRepository _repository;
    private readonly UserManager<AppUser> _userManager;

    public TeamController(ITeamRepository repository, UserManager<AppUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
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

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateTeam([FromBody] CreateTeamDTO createTeamDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;
        var appUser = await _userManager.FindByNameAsync(userName);
        
        var team = _repository.CreateTeam(createTeamDTO, appUser.Id);

        return Ok(team.ToGetUserTeamDTO());
    }
}