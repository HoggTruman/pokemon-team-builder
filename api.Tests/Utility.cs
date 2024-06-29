using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Tests;

public static class Utility
{
    public static ApplicationDbContext CreateTestDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var testDbContext = new ApplicationDbContext(options);
        testDbContext.Database.EnsureCreated();

        return testDbContext;
    }
}