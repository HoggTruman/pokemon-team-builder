using System.Net;
using System.Text.Json;
using api.DTOs.Nature;
using FluentAssertions;


namespace api.IntegrationTests.Controllers;

public class NatureControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public NatureControllerTests()
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

    /*
    Tests require a seeded databse to work. To create one:
        1) Specify the test db connection string in the appsettings.Test.json file under "DB_CONNECTION_STRING"
        2) In the api directory run: dotnet ef database update --connection "(your test db connection string, make sure to remove escape backslash)"
        3) Seed database. (COULD LOAD ENVIRONMENT VARIABLES FOR DEVELOPMENT AND TEST AND THEN ADD A PARAMETER TO SEED TO SEED THE )
    */



    [Fact]
    public async Task GetNatures_ReturnsNatures()
    {
        // Arrange 
        var expectedNature1 = new NatureDTO
        {
            Id = 1,
            Identifier = "hardy",
            AttackMultiplier = 1,
            DefenseMultiplier = 1,
            SpecialAttackMultiplier = 1,
            SpecialDefenseMultiplier = 1,
            SpeedMultiplier = 1
        };

        var expectedNature2 = new NatureDTO
        {
            Id = 11,
            Identifier = "adamant",
            AttackMultiplier = 1.1,
            DefenseMultiplier = 1,
            SpecialAttackMultiplier = 0.9,
            SpecialDefenseMultiplier = 1,
            SpeedMultiplier = 1
        };


        // Act
        var response = await _client.GetAsync("/api/nature");
        var data = JsonSerializer.Deserialize<List<NatureDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var actualNature1 = data?.FirstOrDefault(x => x.Id == expectedNature1.Id);
        var actualNature2 = data?.FirstOrDefault(x => x.Id == expectedNature2.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(actualNature1);
        actualNature1.Should().BeEquivalentTo(expectedNature1);

        Assert.NotNull(actualNature2);
        actualNature2.Should().BeEquivalentTo(expectedNature2);
    }




    [Fact]
    public async void GetNatureById_WithValidId_ReturnsNature()
    {
        // Arrange 
        var expectedNature = new NatureDTO
        {
            Id = 5,
            Identifier = "timid",
            AttackMultiplier = 0.9,
            DefenseMultiplier = 1,
            SpecialAttackMultiplier = 1,
            SpecialDefenseMultiplier = 1,
            SpeedMultiplier = 1.1
        };


        // Act
        var response = await _client.GetAsync($"/api/nature/{expectedNature.Id}");
        var data = JsonSerializer.Deserialize<NatureDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions    
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        data.Should().BeEquivalentTo(expectedNature);
    }




    [Fact]
    public async void GetNatureById_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync($"/api/nature/{-1}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}