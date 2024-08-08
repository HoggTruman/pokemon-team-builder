using System.Net;
using System.Text.Json;
using api.DTOs.Pokemon;
using FluentAssertions;


namespace api.IntegrationTests.Controllers;


//  Tests require a seeded databse to work. To create one:
//      1) Specify the test db connection string in the appsettings.Test.json file under "DB_CONNECTION_STRING"
//      2) In the api directory run: dotnet ef database update --connection "(your test db connection string, make sure to remove escape backslash)"
//      3) Run "dotnet run seed test"



public class PokemonControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public PokemonControllerTests()
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
    public async Task GetAllPokemon_ReturnsPokemon()
    {
        // Arrange 
        var expectedPokemon1 = new PokemonDTO
        {
            Id = 1,
            Identifier = "bulbasaur",
            SpeciesId = 1,
            PokemonPkmnTypes = ["grass", "poison"],
            PokemonGenderIds = [1, 2],
            PokemonAbilityIds = [65, 34],
            PokemonMoveIds = [ 
                13, 14, 15, 20, 22, 29, 33, 34, 36, 38, 45, 70, 72, 73, 74,
                75, 76, 77, 79, 80, 81, 92, 99, 102, 104, 111, 113, 115, 117,
                124, 130, 133, 148, 156, 164, 173, 174, 182, 188, 189, 200,
                202, 203, 204, 206, 207, 210, 213, 214, 216, 218, 219, 230,
                235, 237, 241, 249, 263, 267, 270, 275, 282, 290, 311, 320,
                331, 345, 363, 388, 402, 412, 437, 438, 445, 447, 474, 491,
                496, 497, 520, 526, 580, 590, 803, 851, 885
            ],
            BaseStats = new(){
                HP = 45,
                Attack = 49,
                Defense = 49,
                SpecialAttack = 65,
                SpecialDefense = 65,
                Speed = 45                
            }
        };

        var expectedPokemon2 = new PokemonDTO
        {
            Id = 132,
            Identifier = "ditto",
            SpeciesId = 132,
            PokemonPkmnTypes = ["normal"],
            PokemonGenderIds = [3],
            PokemonAbilityIds = [7, 150],
            PokemonMoveIds = [144],
            BaseStats = new(){
                HP = 48,
                Attack = 48,
                Defense = 48,
                SpecialAttack = 48,
                SpecialDefense = 48,
                Speed = 48                
            }
        };


        // Act
        var response = await _client.GetAsync("/api/pokemon");
        var data = JsonSerializer.Deserialize<List<PokemonDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var actualPokemon1 = data?.FirstOrDefault(x => x.Id == expectedPokemon1.Id);
        var actualPokemon2 = data?.FirstOrDefault(x => x.Id == expectedPokemon2.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(actualPokemon1);
        actualPokemon1.Should().BeEquivalentTo(expectedPokemon1);

        Assert.NotNull(actualPokemon2);
        actualPokemon2.Should().BeEquivalentTo(expectedPokemon2);
    }




    [Fact]
    public async void GetPokemonById_WithValidId_ReturnsPokemon()
    {
        // Arrange 
        var expectedPokemon = new PokemonDTO
{
            Id = 25,
            Identifier = "pikachu",
            SpeciesId = 25,
            PokemonPkmnTypes = ["electric"],
            PokemonGenderIds = [1, 2],
            PokemonAbilityIds = [9, 31],
            PokemonMoveIds = [ 
                5, 6, 9, 21, 24, 25, 29, 34, 36, 38, 39, 45, 57, 66, 68, 69,
                70, 84, 85, 86, 87, 91, 92, 97, 98, 99, 102, 104, 111, 113, 115,
                117, 129, 130, 148, 156, 164, 168, 173, 174, 179, 182, 186, 189,
                192, 197, 203, 204, 205, 207, 209, 213, 214, 216, 218, 223, 227,
                231, 237, 240, 249, 253, 263, 264, 268, 270, 280, 282, 283, 290,
                313, 324, 343, 344, 347, 351, 363, 364, 374, 393, 417, 435, 445,
                447, 451, 486, 496, 497, 521, 527, 528, 574, 577, 583, 589, 590,
                598, 604, 609, 673, 804, 851, 885, 914, 918
            ],
            BaseStats = new(){
                HP = 35,
                Attack = 55,
                Defense = 40,
                SpecialAttack = 50,
                SpecialDefense = 50,
                Speed = 90                
            }
        };


        // Act
        var response = await _client.GetAsync($"/api/pokemon/{expectedPokemon.Id}");
        var data = JsonSerializer.Deserialize<PokemonDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions    
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        data.Should().BeEquivalentTo(expectedPokemon);
    }




    [Fact]
    public async void GetPokemonById_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync($"/api/pokemon/{-1}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}