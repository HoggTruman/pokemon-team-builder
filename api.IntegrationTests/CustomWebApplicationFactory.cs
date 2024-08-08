using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

using Microsoft.Extensions.Hosting;


namespace api.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> 
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
    }
}