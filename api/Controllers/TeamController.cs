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
    public async Task<IActionResult> GetTeams()
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
    public async Task<IActionResult> GetTeamById([FromRoute] int id)
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
    public async Task<IActionResult> CreateTeam([FromBody] CreateUpdateTeamDTO createTeamDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;
        var appUser = await _userManager.FindByNameAsync(userName);

        if (appUser == null)
            return Unauthorized();
        
        var team = _repository.CreateTeam(createTeamDTO, appUser.Id);

        return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team.ToGetUserTeamDTO());
    }


    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<IActionResult> UpdateTeam([FromBody] CreateUpdateTeamDTO updateTeamDTO, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;
        var appUser = await _userManager.FindByNameAsync(userName);

        if (appUser == null)
            return Unauthorized();

        var team = _repository.UpdateTeam(updateTeamDTO, id, appUser.Id);

        if (team == null)
            return NotFound();

        return Ok(team.ToGetUserTeamDTO());
    }


    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userName = User.FindFirstValue(ClaimTypes.GivenName)!;
        var appUser = await _userManager.FindByNameAsync(userName);

        if (appUser == null)
            return Unauthorized();

        var team = _repository.DeleteTeamById(id, appUser.Id);

        if (team == null)
            return NotFound();

        return NoContent();
    }
}