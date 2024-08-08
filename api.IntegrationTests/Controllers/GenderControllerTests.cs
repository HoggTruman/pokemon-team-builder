using System.Net;
using System.Text.Json;
using api.DTOs.Gender;
using FluentAssertions;


namespace api.IntegrationTests.Controllers;



//  Tests require a seeded databse to work. To create one:
//      1) Specify the test db connection string in the appsettings.Test.json file under "DB_CONNECTION_STRING"
//      2) In the api directory run: dotnet ef database update --connection "(your test db connection string, make sure to remove escape backslash)"
//      3) Run "dotnet run seed test"



public class GenderControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public GenderControllerTests()
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
    public async Task GetGenders_ReturnsGenders()
    {
        // Arrange 
        var expectedGender1 = new GenderDTO
        {
            Id = 1,
            Identifier = "female",
        };

        var expectedGender2 = new GenderDTO
        {
            Id = 3,
            Identifier = "genderless",
        };


        // Act
        var response = await _client.GetAsync("/api/gender");
        var data = JsonSerializer.Deserialize<List<GenderDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var actualGender1 = data?.FirstOrDefault(x => x.Id == expectedGender1.Id);
        var actualGender2 = data?.FirstOrDefault(x => x.Id == expectedGender2.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(actualGender1);
        actualGender1.Should().BeEquivalentTo(expectedGender1);

        Assert.NotNull(actualGender2);
        actualGender2.Should().BeEquivalentTo(expectedGender2);
    }




    [Fact]
    public async void GetGenderById_WithValidId_ReturnsGender()
    {
        // Arrange 
        var expectedGender = new GenderDTO
        {
            Id = 2,
            Identifier = "male",
        };


        // Act
        var response = await _client.GetAsync($"/api/gender/{expectedGender.Id}");
        var data = JsonSerializer.Deserialize<GenderDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions    
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        data.Should().BeEquivalentTo(expectedGender);
    }




    [Fact]
    public async void GetGenderById_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync($"/api/gender/{-1}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}