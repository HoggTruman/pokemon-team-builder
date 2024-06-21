using api.Data;
using api.DTOs.Team;
using api.Interfaces.Repository;
using api.Models.User;
using Microsoft.EntityFrameworkCore;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;

    public TeamRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    // used for team select page so no need to include pokemon at this point??
    // maybe include pokemon icons at some point though??
    public List<Team>? GetAllByUserName(string userName)
    {
        var user = _context.Users
            .Include(x => x.Teams)
            .FirstOrDefault(x => x.UserName == userName);

        if (user == null)
        {
            return null;
        }

        var teams = user.Teams
            .ToList();

        return teams;
    }


    // used to load a specific team for editing
    public Team? GetById(int id)
    {
        var team = _context.Team
            .Include(x => x.UserPokemon)                                // PROBABLY NEEDS A MILLION INCLUDES
            .FirstOrDefault(x => x.Id == id);

        return team;
    }


    public Team? UpdateTeamById(int id, UpdateTeamDTO updateTeamDTO)
    {
        throw new NotImplementedException();
    }


    public Team? CreateTeam(CreateTeamDTO createTeamDTO)
    {
        throw new NotImplementedException();
    }


    public void DeleteTeamById(int id)
    {
        throw new NotImplementedException();
    }

}