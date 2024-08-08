using System.Net;
using System.Text.Json;
using api.DTOs.Ability;
using FluentAssertions;


namespace api.IntegrationTests.Controllers;


//  Tests require a seeded databse to work. To create one:
//      1) Specify the test db connection string in the appsettings.Test.json file under "DB_CONNECTION_STRING"
//      2) In the api directory run: dotnet ef database update --connection "(your test db connection string, make sure to remove escape backslash)"
//      3) Run "dotnet run seed test"



public class AbilityControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public AbilityControllerTests()
    {
        _factory = new CustomWebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    public void Dispose()
    {
        _factory.Dispose();
        _client.Dispose();
    }

    readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };





    [Fact]
    public async Task GetAbilities_ReturnsAbilities()
    {
        // Arrange 
        var expectedAbility1 = new AbilityDTO
        {
            Id = 1,
            Identifier = "stench",
            FlavorText = "By releasing a stench when attacking, the Pokémon may cause the target to flinch."
        };

        var expectedAbility2 = new AbilityDTO
        {
            Id = 37,
            Identifier = "huge-power",
            FlavorText = "Doubles the Pokémon's Attack stat."
        };


        // Act
        var response = await _client.GetAsync("/api/ability");
        var data = JsonSerializer.Deserialize<List<AbilityDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var actualAbility1 = data?.FirstOrDefault(x => x.Id == expectedAbility1.Id);
        var actualAbility2 = data?.FirstOrDefault(x => x.Id == expectedAbility2.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(actualAbility1);
        actualAbility1.Should().BeEquivalentTo(expectedAbility1);

        Assert.NotNull(actualAbility2);
        actualAbility2.Should().BeEquivalentTo(expectedAbility2);
    }




    [Fact]
    public async void GetAbilityById_WithValidId_ReturnsAbility()
    {
        // Arrange 
        var expectedAbility = new AbilityDTO
        {
            Id = 9,
            Identifier = "static",
            FlavorText = "The Pokémon is charged with static electricity and may paralyze attackers that make direct contact with it."
        };


        // Act
        var response = await _client.GetAsync($"/api/ability/{expectedAbility.Id}");
        var data = JsonSerializer.Deserialize<AbilityDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        data.Should().BeEquivalentTo(expectedAbility);
    }




    [Fact]
    public async void GetAbilityById_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync($"/api/ability/{-1}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}