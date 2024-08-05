using System.Data.Common;
using api.Data;
using api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace api.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> 
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services => 
        {
            // Remove DbContextOptions and DbConnection specified in Program.cs
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>)
            )!;

            services.Remove(dbContextDescriptor);

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbConnection)
            )!;

            services.Remove(dbConnectionDescriptor);


            // Create new DbConnection
            var testDbConnectionString = AppConfig.TestDbConnectionString;

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(testDbConnectionString);
                options.EnableSensitiveDataLogging();
            });
        });

        builder.UseEnvironment("Development");
        
    }
}