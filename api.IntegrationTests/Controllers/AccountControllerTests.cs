using System.Net;
using System.Text;
using System.Text.Json;
using api.Data;
using api.DTOs.Account;
using api.Models.User;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace api.IntegrationTests.Controllers;

public class AccountControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<AppUser> _userManager;

    public AccountControllerTests()
    {
        _factory = new CustomWebApplicationFactory<Program>();
        _client = _factory.CreateClient();
        _dbContext = _factory.Services.GetRequiredService<ApplicationDbContext>();
        _userManager = _factory.Services.GetRequiredService<UserManager<AppUser>>();

        // Clear All Users
        _dbContext.Users.ExecuteDelete();
    }

    public void Dispose()
    {
        _factory.Dispose();
        _client.Dispose();
    }

    readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };




    [Fact]
    public async void Login_WithValidInput_ReturnsAuthorizedUser()
    {
        // Arrange
        AppUser testAppUser = new()
        {
            UserName = "TestUser"
        };
        string password = "password1";

        var userCreationResult = await _userManager.CreateAsync(testAppUser, password);
        Assert.True(userCreationResult.Succeeded);

        LoginDTO loginDTO = new()
        {
            UserName = testAppUser.UserName,
            Password = password
        };

        var postContent = new StringContent(
            JsonSerializer.Serialize(loginDTO), 
            Encoding.UTF8, 
            "application/json"
        );


        // Act
        var response = await _client.PostAsync("api/account/login", postContent);
        var data = JsonSerializer.Deserialize<AuthorizedUserDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);

        Assert.Equal(loginDTO.UserName, data.UserName);
        Assert.NotEqual("", data.Token);
    }




    [Fact]
    public async void Register_WithValidInput_ReturnsAuthorizedUser()
    {
        // Arrange
        RegisterDTO registerDTO = new()
        {
            UserName = "TestUser",
            Password = "password1",
            ConfirmPassword = "password1"
        };

        var content = new StringContent(
            JsonSerializer.Serialize(registerDTO), 
            Encoding.UTF8, 
            "application/json"
        );


        // Act
        var response = await _client.PostAsync("api/account/register", content);
        var data = JsonSerializer.Deserialize<AuthorizedUserDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);

        Assert.Equal(registerDTO.UserName, data.UserName);
        Assert.NotEqual("", data.Token);
    }

}