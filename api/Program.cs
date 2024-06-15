using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseSqlServer(builder.Configuration["DB_CONNECTION_STRING"]);
    options.EnableSensitiveDataLogging();
});

builder.Services.AddLogging(loggingBuilder => {
    loggingBuilder.AddConsole()
        .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
    loggingBuilder.AddDebug();
});


// Add Repositories
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IMoveRepository, MoveRepository>();



builder.Services.AddScoped<DbInitializer>();
builder.Services.AddScoped<DbToCSV>();


var app = builder.Build();



var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope()) {
    // Add Seed Data to DB
    var dbInitializer = scope.ServiceProvider.GetService<DbInitializer>()!;
    dbInitializer.SeedAll();
    

    // Development tool to write Database to csv files
    // Writes DB data for each model to a corresponding csv file in /Data/WriteData
    if (builder.Configuration["WRITE_TO_CSV"] == "TRUE")
    {
        var dbToCSV = scope.ServiceProvider.GetService<DbToCSV>()!;
        dbToCSV.WriteAllToCSV();
    }

}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
