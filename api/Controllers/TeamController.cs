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
    public async Task<IActionResult> GetUserTeams()
    {
        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;
        var appUser = await _userManager.FindByNameAsync(userName);

        if (appUser == null)
            return Unauthorized();

        var teams = _repository.GetTeams(appUser.Id);

        if (teams == null)
        {
            return NotFound();
        }
            

        return Ok(teams.Select(x => x.ToGetUserTeamsDTO()));
    }


    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetUserTeamById([FromRoute] int id)
    {
        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;
        var appUser = await _userManager.FindByNameAsync(userName);

        if (appUser == null)
            return Unauthorized();

        var team = _repository.GetTeamById(id, appUser.Id);

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

        if (appUser == null)
            return Unauthorized();
        
        var team = _repository.CreateTeam(createTeamDTO, appUser.Id);

        return Ok(team.ToGetUserTeamDTO());
    }


    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamDTO updateTeamDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;
        var appUser = await _userManager.FindByNameAsync(userName);

        if (appUser == null)
            return Unauthorized();

        var team = _repository.UpdateTeam(updateTeamDTO, appUser.Id);

        if (team == null)
            return NotFound();

        return Ok(team.ToGetUserTeamDTO());
    }
}