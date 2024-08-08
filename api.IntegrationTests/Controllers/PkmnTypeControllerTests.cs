using System.Net;
using System.Text.Json;
using api.DTOs.PkmnType;
using FluentAssertions;


namespace api.IntegrationTests.Controllers;

public class PkmnTypeControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public PkmnTypeControllerTests()
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
    public async Task GetPkmnTypes_ReturnsPkmnTypes()
    {
        // Arrange 
        var expectedPkmnType1 = new PkmnTypeDTO
        {
            Id = 1,
            Identifier = "normal",
        };

        var expectedPkmnType2 = new PkmnTypeDTO
        {
            Id = 7,
            Identifier = "bug",
        };


        // Act
        var response = await _client.GetAsync("/api/type");
        var data = JsonSerializer.Deserialize<List<PkmnTypeDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var actualPkmnType1 = data?.FirstOrDefault(x => x.Id == expectedPkmnType1.Id);
        var actualPkmnType2 = data?.FirstOrDefault(x => x.Id == expectedPkmnType2.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(actualPkmnType1);
        actualPkmnType1.Should().BeEquivalentTo(expectedPkmnType1);

        Assert.NotNull(actualPkmnType2);
        actualPkmnType2.Should().BeEquivalentTo(expectedPkmnType2);
    }




    [Fact]
    public async void GetPkmnTypeById_WithValidId_ReturnsPkmnType()
    {
        // Arrange 
        var expectedPkmnType = new PkmnTypeDTO
        {
            Id = 13,
            Identifier = "electric",
        };


        // Act
        var response = await _client.GetAsync($"/api/type/{expectedPkmnType.Id}");
        var data = JsonSerializer.Deserialize<PkmnTypeDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions    
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        data.Should().BeEquivalentTo(expectedPkmnType);
    }




    [Fact]
    public async void GetPkmnTypeById_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync($"/api/type/{-1}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}