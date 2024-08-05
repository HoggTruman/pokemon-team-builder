namespace api.IntegrationTests.Controllers;

public class AbilityControllerTests
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public AbilityControllerTests()
    {
        _factory = new CustomWebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    /*
    Tests require a seeded databse to work. To create one:
        1) Specify the test db connection string in the api .env file under "TEST_DB_CONNECTION_STRING"
        2) In the api directory run: dotnet ef database update --connection "(your connection string goes here)"
        3) Seed database. (NEED TO FIGURE OUT A BETTER WAY)
    */



    [Fact]
    public void Test_Test()
    {
        Assert.Equal(1, 1);
    }
}