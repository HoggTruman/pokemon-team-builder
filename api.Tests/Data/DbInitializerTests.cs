using api.Data;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace api.Tests.Data;


public class DbInitializerTests
{
    private readonly Mock<IServiceScopeFactory> _scopeFactory;

    public DbInitializerTests()
    {
        _scopeFactory = MockHelpers.CreateMockServiceScopeFactory();
    }



    [Fact]
    public void SeedAll_AddsAllToDb()
    {
        // Arrange
        var dbInitializer = new DbInitializer(_scopeFactory.Object);

        // Act
        // dbInitializer.SeedAll();

        // Assert
    }
}