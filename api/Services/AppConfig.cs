namespace api.Services;

public class AppConfig
{
    public static string? TestDbConnectionString { get; set; }

    public AppConfig(IConfiguration config)
    {
        TestDbConnectionString = config["TEST_DB_CONNECTION"];
    }
}