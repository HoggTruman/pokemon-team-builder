using System.Net;
using System.Text.Json;
using api.DTOs.Item;
using FluentAssertions;


namespace api.IntegrationTests.Controllers;



//  Tests require a seeded databse to work. To create one:
//      1) Specify the test db connection string in the appsettings.Test.json file under "DB_CONNECTION_STRING"
//      2) In the api directory run: dotnet ef database update --connection "(your test db connection string, make sure to remove escape backslash)"
//      3) Run "dotnet run seed test"



public class ItemControllerTests : IDisposable
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public ItemControllerTests()
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
    public async Task GetItems_ReturnsItems()
    {
        // Arrange 
        var expectedItem1 = new ItemDTO
        {
            Id = 1,
            Identifier = "master-ball",
            Effect = "Catches a wild Pokémon every time."
        };

        var expectedItem2 = new ItemDTO
        {
            Id = 11,
            Identifier = "luxury-ball",
            Effect = "Tries to catch a wild Pokémon.  Caught Pokémon start with 200 happiness."
        };


        // Act
        var response = await _client.GetAsync("/api/item");
        var data = JsonSerializer.Deserialize<List<ItemDTO>>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );
        var actualItem1 = data?.FirstOrDefault(x => x.Id == expectedItem1.Id);
        var actualItem2 = data?.FirstOrDefault(x => x.Id == expectedItem2.Id);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        Assert.NotEmpty(data);

        Assert.NotNull(actualItem1);
        actualItem1.Should().BeEquivalentTo(expectedItem1);

        Assert.NotNull(actualItem2);
        actualItem2.Should().BeEquivalentTo(expectedItem2);
    }




    [Fact]
    public async void GetItemById_WithValidId_ReturnsItem()
    {
        // Arrange 
        var expectedItem = new ItemDTO
        {
            Id = 25,
            Identifier = "hyper-potion",
            Effect = "Restores 200 HP."
        };


        // Act
        var response = await _client.GetAsync($"/api/item/{expectedItem.Id}");
        var data = JsonSerializer.Deserialize<ItemDTO>(
            await response.Content.ReadAsStringAsync(),
            jsonOptions
        );


        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(data);
        data.Should().BeEquivalentTo(expectedItem);
    }




    [Fact]
    public async void GetItemById_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var response = await _client.GetAsync($"/api/item/{-1}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

}