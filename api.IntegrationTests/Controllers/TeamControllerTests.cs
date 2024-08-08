using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using api.Data;
using api.DTOs.Team;
using api.DTOs.UserPokemon;
using api.Interfaces;
using api.Mappers;
using api.Models.User;
using api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace api.IntegrationTests.Controllers;


// Added to collection to prevent concurrency issues with AccountControllerTests
[Collection("Sequential")]
public class TeamControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;


    public TeamControllerTests()
    {
        _factory = new CustomWebApplicationFactory<Program>();
        _client = _factory.CreateClient();
        _dbContext = _factory.Services.GetRequiredService<ApplicationDbContext>();
        _userManager = _factory.Services.GetRequiredService<UserManager<AppUser>>();
        _tokenService = _factory.Services.GetRequiredService<ITokenService>();

        // Reset teams and users
        _dbContext.UserPokemon.ExecuteDelete();
        _dbContext.Team.ExecuteDelete();
    }

    public void Dispose()
    {
        _factory.Dispose();
        _client.Dispose();
        _dbContext.Dispose();
    }

    private async Task<bool> SetupAsync(AppUser appUser)
    {
        // delete existing test user
        var user = await _userManager.FindByNameAsync(testUserName);
        if (user != null)
        {
            var deleteResult = await _userManager.DeleteAsync(user);
            if (deleteResult.Succeeded == false)
            {
                return deleteResult.Succeeded;
            }
        }

        // create new test user
        var userCreationResult = await _userManager.CreateAsync(appUser, "password1");
        if (userCreationResult.Succeeded)
        {
            var token = _tokenService.CreateToken(appUser);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        
        return userCreationResult.Succeeded;
    }
   

    readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };
    readonly string testUserName = "TestUser";




    [Fact]
    public async void GetTeams_WhenUserHasTeams_ReturnsTeams()
    {
        // Arrange 
        AppUser testAppUser = new(){ UserName = testUserName };
        Assert.True(await SetupAsync(testAppUser), "SetupAsync Failed");

        var testTeam = new Team()
        {
            AppUserId = testAppUser.Id,
            TeamName = "Test Team",
        };

        UserPokemon pokemon = new()
        {
            TeamId = testTeam.Id,
            TeamSlot = 1,
            PokemonId = 1,
            ItemId = 5,
            AbilityId = 65,
            Move1Id = 13,
            Move3Id = 14,
            SpecialAttackEV = 200,
            SpeedIV = 0,
        };

        testTeam.UserPokemon = [pokemon];

        _dbContext.Team.Add(testTeam);
        _dbContext.SaveChanges();

        List<GetTeamDTO> expectedData = [testTeam.ToGetTeamDTO()];


        // Act
        var response = await _client.GetAsync("api/teams");
        var data = JsonSerializer.Deserialize<List<GetTeamDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        data.Should().BeEquivalentTo(expectedData, 
            options => options.WithStrictOrdering());
    }




    [Fact]
    public async void PostTeams_ReturnsTeams()
    {
        // Arrange
        AppUser testAppUser = new(){ UserName = testUserName };
        Assert.True(await SetupAsync(testAppUser), "SetupAsync Failed");

        CreateTeamsDTO postTeam = new()
        {
            Id = -1,
            TeamName = "TestTeam",
        };

        CreateUserPokemonDTO postPokemon = new()
        {
            TeamSlot = 1,
            PokemonId = 1,
            ItemId = 5,
            AbilityId = 65,
            Move1Id = 13,
            Move3Id = 14,
            SpecialAttackEV = 200,
            SpeedIV = 0,
        };

        postTeam.UserPokemon = [postPokemon];
        List<CreateTeamsDTO> teamDTOs = [postTeam];

        var postContent = new StringContent(
            JsonSerializer.Serialize(teamDTOs), 
            Encoding.UTF8, 
            "application/json"
        );


        // Act
        var response = await _client.PostAsync("api/teams", postContent);
        var data = JsonSerializer.Deserialize<List<GetTeamDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var responseTeam = data?.ElementAt(0);
        var dbResult = _dbContext.Team.FirstOrDefault(x => x.TeamName == postTeam.TeamName);


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(responseTeam);
        Assert.Equal(postTeam.TeamName, responseTeam.TeamName);
        responseTeam.UserPokemon[0].Should().BeEquivalentTo(postPokemon);

        Assert.NotNull(dbResult);
    }




    [Fact]
    public async void GetTeamById_WithValidId_ReturnsTeam()
    {
        // Arrange 
        AppUser testAppUser = new(){ UserName = testUserName };
        Assert.True(await SetupAsync(testAppUser), "SetupAsync Failed");

        var testTeam = new Team()
        {
            AppUserId = testAppUser.Id,
            TeamName = "Test Team",
        };

        UserPokemon pokemon = new()
        {
            TeamId = testTeam.Id,
            TeamSlot = 1,
            PokemonId = 1,
            ItemId = 5,
            AbilityId = 65,
            Move1Id = 13,
            Move3Id = 14,
            SpecialAttackEV = 200,
            SpeedIV = 0,
        };

        testTeam.UserPokemon = [pokemon];

        _dbContext.Team.Add(testTeam);
        _dbContext.SaveChanges();

        GetTeamDTO expectedData = testTeam.ToGetTeamDTO();


        // Act
        var response = await _client.GetAsync($"api/team/{testTeam.Id}");
        var data = JsonSerializer.Deserialize<GetTeamDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);

        data.Should().BeEquivalentTo(expectedData, 
            options => options.WithStrictOrdering());
    }




    [Fact]
    public async void UpdateTeamById_WithValidId_ReturnsTeam()
    {
        // Arrange 
        AppUser testAppUser = new(){ UserName = testUserName };
        Assert.True(await SetupAsync(testAppUser), "SetupAsync Failed");

        var testTeam = new Team()
        {
            AppUserId = testAppUser.Id,
            TeamName = "Test Team",
        };

        _dbContext.Team.Add(testTeam);
        _dbContext.SaveChanges();


        CreateUserPokemonDTO pokemonDTO = new()
        {
            TeamSlot = 1,
            PokemonId = 1,
            ItemId = 5,
            AbilityId = 65,
            Move1Id = 13,
            Move3Id = 14,
            SpecialAttackEV = 200,
            SpeedIV = 0,
        };

        CreateUpdateTeamDTO updateTeamDTO = new()
        {
            TeamName = "Updated Team Name",
            UserPokemon = [pokemonDTO],
        };

        var putContent = new StringContent(
            JsonSerializer.Serialize(updateTeamDTO), 
            Encoding.UTF8, 
            "application/json"
        );


        GetTeamDTO expectedData = new()
        {
            Id = testTeam.Id,
            TeamName = updateTeamDTO.TeamName,
            UserPokemon = [
                new()
                {   
                    TeamSlot = pokemonDTO.TeamSlot,
                    PokemonId = pokemonDTO.PokemonId,
                    ItemId = pokemonDTO.ItemId,
                    AbilityId = pokemonDTO.AbilityId,
                    Move1Id = pokemonDTO.Move1Id,
                    Move3Id = pokemonDTO.Move3Id,
                    SpecialAttackEV = pokemonDTO.SpecialAttackEV,
                    SpeedIV = pokemonDTO.SpeedIV,
                }
            ]
        };


        // Act
        var response = await _client.PutAsync($"api/team/{testTeam.Id}", putContent);
        var data = JsonSerializer.Deserialize<GetTeamDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        _dbContext.Entry(testTeam).Reload();


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.Equal(expectedData.TeamName, data.TeamName);
        data.UserPokemon[0].Should().BeEquivalentTo(expectedData.UserPokemon[0], options => 
            options.Excluding(x => x.Id));

        Assert.Equal(expectedData.TeamName, testTeam.TeamName);         
    }




    [Fact]
    public async void DeleteTeamById_WithValidId_ReturnsNoContent()
    {
        // Arrange 
        AppUser testAppUser = new(){ UserName = testUserName };
        Assert.True(await SetupAsync(testAppUser), "SetupAsync Failed");

        var testTeam = new Team()
        {
            AppUserId = testAppUser.Id,
            TeamName = "Test Team",
        };

        UserPokemon pokemon = new()
        {
            TeamId = testTeam.Id,
            TeamSlot = 1,
            PokemonId = 1,
            ItemId = 5,
            AbilityId = 65,
            Move1Id = 13,
            Move3Id = 14,
            SpecialAttackEV = 200,
            SpeedIV = 0,
        };

        testTeam.UserPokemon = [pokemon];

        _dbContext.Team.Add(testTeam);
        _dbContext.SaveChanges();


        // Act
        var response = await _client.DeleteAsync($"api/team/{testTeam.Id}");
        var data = await response.Content.ReadAsStringAsync();
        var dbTeam = _dbContext.Team.FirstOrDefault(x => x.Id == testTeam.Id);
        var dbUserPokemon = _dbContext.UserPokemon.FirstOrDefault(x => x.TeamId == testTeam.Id);


        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.Empty(data);

        Assert.Null(dbTeam);
        Assert.Null(dbUserPokemon);

    }




        [Fact]
    public async void PostTeam_ReturnsTeam()
    {
        // Arrange
        AppUser testAppUser = new(){ UserName = testUserName };
        Assert.True(await SetupAsync(testAppUser), "SetupAsync Failed");

        CreateUpdateTeamDTO postTeamDTO = new()
        {
            TeamName = "TestTeam",
        };

        CreateUserPokemonDTO postPokemon = new()
        {
            TeamSlot = 1,
            PokemonId = 1,
            ItemId = 5,
            AbilityId = 65,
            Move1Id = 13,
            Move3Id = 14,
            SpecialAttackEV = 200,
            SpeedIV = 0,
        };

        postTeamDTO.UserPokemon = [postPokemon];

        var postContent = new StringContent(
            JsonSerializer.Serialize(postTeamDTO), 
            Encoding.UTF8, 
            "application/json"
        );


        // Act
        var response = await _client.PostAsync("api/team", postContent);
        var data = JsonSerializer.Deserialize<GetTeamDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var dbTeamResult = _dbContext.Team.FirstOrDefault(x => x.TeamName == postTeamDTO.TeamName);
        var dbPokemonResult = _dbContext.UserPokemon.FirstOrDefault();


        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.NotNull(data);

        Assert.Equal(postTeamDTO.TeamName, data.TeamName);
        data.UserPokemon[0].Should().BeEquivalentTo(postPokemon);

        Assert.NotNull(dbTeamResult);
        Assert.NotNull(dbPokemonResult);
        dbPokemonResult.Should().BeEquivalentTo(postPokemon);
    }


}