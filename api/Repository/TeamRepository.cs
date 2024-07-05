using api.Data;
using api.DTOs.Team;
using api.Interfaces.Repository;
using api.Mappers;
using api.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public TeamRepository(ApplicationDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    // used for team select page so no need to include pokemon at this point
    // by the time this method is called, we assume the user is valid so can just return an empty list if no entries are found
    // maybe include pokemon icons at some point though??
    public List<Team> GetTeams(string userId)
    {
        var teams = _context.Team
            .Where(x => x.AppUserId == userId)
            .ToList();

        return teams;
    }


    // used to load a specific team for editing
    public Team? GetTeamById(int id, string userId)
    {
        var team = _context.Team
            .Include(x => x.UserPokemon)
            .FirstOrDefault(x => x.AppUserId == userId && x.Id == id);

        return team;
    }


    public Team CreateTeam(CreateUpdateTeamDTO createTeamDTO, string userId)
    {
        var team = new Team
        {
            AppUserId = userId,
            TeamName = createTeamDTO.TeamName,
        };

        var userPokemon = createTeamDTO.UserPokemon.Select(x => x.ToUserPokemon()).ToList();
        userPokemon.ForEach(x => x.TeamId = team.Id);

        team.UserPokemon = userPokemon; 


        _context.Team.Add(team);
        _context.SaveChanges();

        return team;
    }


    public Team? UpdateTeam(CreateUpdateTeamDTO updateTeamDTO, int id, string userId)
    {
        var team = _context.Team
            .Include(x => x.UserPokemon)
            .FirstOrDefault(x => x.AppUserId == userId && x.Id == id);

        if (team == null)
        {
            return null;
        }

        team.TeamName = updateTeamDTO.TeamName;

        _context.UserPokemon.RemoveRange(team.UserPokemon);

        var newUserPokemon = updateTeamDTO.UserPokemon.Select(x => x.ToUserPokemon()).ToList();
        newUserPokemon.ForEach(x => x.TeamId = team.Id);

        team.UserPokemon = newUserPokemon;


        _context.SaveChanges();

        return team;
    }


    public Team? DeleteTeamById(int id, string userId)
    {
        var team = _context.Team
            .FirstOrDefault(x => x.AppUserId == userId && x.Id == id);

        if (team != null)
        {
            _context.Team.Remove(team);
            _context.SaveChanges();
        }

        return team;
    }
}