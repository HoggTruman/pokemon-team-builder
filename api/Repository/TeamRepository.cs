using api.Data;
using api.DTOs.Team;
using api.Interfaces.Repository;
using api.Mappers;
using api.Models.User;
using Microsoft.EntityFrameworkCore;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;

    public TeamRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    // by the time this method is called, we assume the user is valid so can just return an empty list if no entries are found
    public List<Team> GetTeams(string userId)
    {
        var teams = _context.Team
            .Include(x => x.UserPokemon)
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


    public Team? UpdateTeamById(int id, CreateUpdateTeamDTO updateTeamDTO, string userId)
    {
        // Note: UserPokemon are deleted and recreated currently so will have different Ids after update
        
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


    public List<Team> CreateUpdateTeams(List<CreateUpdateTeamsDTO> teamDTOs, string userId)
    {
        foreach (CreateUpdateTeamsDTO teamDTO in teamDTOs) {
            // Negative Id corresponds to a new team (not currently in DB)
            if (teamDTO.Id < 0) 
            {
                var team = new Team
                {
                    AppUserId = userId,
                    TeamName = teamDTO.TeamName,
                };

                var userPokemon = teamDTO.UserPokemon.Select(x => x.ToUserPokemon()).ToList();
                userPokemon.ForEach(x => x.TeamId = team.Id);

                team.UserPokemon = userPokemon;

                _context.Team.Add(team);
            }
            // Positive Id corresponds to a team that exists in the DB
            else if (teamDTO.Id > 0) 
            {
                var team = _context.Team
                    .Include(x => x.UserPokemon)
                    .FirstOrDefault(x => x.AppUserId == userId && x.Id == teamDTO.Id);

                if (team == null)
                {
                    continue;
                }

                team.TeamName = teamDTO.TeamName;

                _context.UserPokemon.RemoveRange(team.UserPokemon);

                var newUserPokemon = teamDTO.UserPokemon.Select(x => x.ToUserPokemon()).ToList();
                newUserPokemon.ForEach(x => x.TeamId = team.Id);

                team.UserPokemon = newUserPokemon;
            }
        }

        _context.SaveChanges();

        var teams = _context.Team
            .Include(x => x.UserPokemon)
            .Where(x => x.AppUserId == userId)
            .ToList();

        return teams;
    }
}