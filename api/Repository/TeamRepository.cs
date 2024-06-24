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


    // used for team select page so no need to include pokemon at this point??
    // maybe include pokemon icons at some point though??
    public List<Team> GetTeamsByUserName(string userName)
    {
        var teams = _context.Team
            .Include(x => x.AppUser)
            .Where(x => x.AppUser.UserName == userName)
            .ToList();

        return teams;
    }


    // used to load a specific team for editing
    public Team? GetTeamByUserNameAndId(string username, int id)
    {
        var team = _context.Team
            .Include(x => x.UserPokemon)   // PROBABLY NEEDS A MILLION INCLUDES
            .Include(x => x.AppUser)
            .FirstOrDefault(x => x.AppUser.UserName == username && x.Id == id);

        return team;
    }

    public Team CreateTeam(CreateTeamDTO createTeamDTO, string userId)
    {
        // var appUser = await _userManager.FindByNameAsync(userName);

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

    public Team? UpdateTeamById(int id, UpdateTeamDTO updateTeamDTO)
    {
        // need to take care of deleting userpokemon that are no longer present??
        throw new NotImplementedException();
    }





    public void DeleteTeamById(int id)
    {
        throw new NotImplementedException();
    }

}