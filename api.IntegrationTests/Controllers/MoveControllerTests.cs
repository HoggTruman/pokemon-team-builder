using System.Net;
using System.Text.Json;
using api.DTOs.Move;
using FluentAssertions;


namespace api.IntegrationTests.Controllers;

public class MoveControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public MoveControllerTests()
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
    public async Task GetMoves_ReturnsMoves()
    {
        // Arrange 
        var expectedMove1 = new GetMoveDTO
        {
            Id = 1,
            Identifier = "pound",
            Power = 40,
            PP = 35,
            Accuracy = 100,
            Priority = 0,
            PkmnType = "normal",
            DamageClass = "physical",
            MoveEffect = "Inflicts regular damage with no additional effect.",
            MoveEffectChance = null,
        };

        var expectedMove2 = new GetMoveDTO
        {
            Id = 14,
            Identifier = "swords-dance",
            Power = null,
            PP = 20,
            Accuracy = null,
            Priority = 0,
            PkmnType = "normal",
            DamageClass = "status",
            MoveEffect = "Raises the user's Attack by two stages.",
            MoveEffectChance = null,
        };


        // Act
        var response = await _client.GetAsync("/api/move");
        var data = JsonSerializer.Deserialize<List<GetMoveDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var actualMove1 = data?.FirstOrDefault(x => x.Id == expectedMove1.Id);
        var actualMove2 = data?.FirstOrDefault(x => x.Id == expectedMove2.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(actualMove1);
        actualMove1.Should().BeEquivalentTo(expectedMove1);

        Assert.NotNull(actualMove2);
        actualMove2.Should().BeEquivalentTo(expectedMove2);
    }




    [Fact]
    public async void GetMovesByPokemonId_WithValidId_ReturnsMove()
    {
        // Arrange
        const int testPokemonId = 25;
        var expectedMove = new GetMoveDTO
        {
            Id = 85,
            Identifier = "thunderbolt",
            Power = 90,
            PP = 15,
            Accuracy = 100,
            Priority = 0,
            PkmnType = "electric",
            DamageClass = "special",
            MoveEffect = "Has a $effect_chance% chance to [paralyze]{mechanic:paralysis} the target.",
            MoveEffectChance = 10
        };


        // Act
        var response = await _client.GetAsync($"/api/move/{testPokemonId}");
        var data = JsonSerializer.Deserialize<List<GetMoveDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var actualMove = data?.FirstOrDefault(x => x.Id == expectedMove.Id);


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(actualMove);
        actualMove.Should().BeEquivalentTo(expectedMove);
    }




    [Fact]
    public async void GetMovesByPokemonId_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync($"/api/move/{-1}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}