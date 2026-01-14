using System.Globalization;
using api.Mappers.CSVClassMaps;
using api.Models.Static;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class DbToCSV
{
    private const string WriteDir = @"Data\WriteData";
    private readonly IServiceScopeFactory _scopeFactory;
    

    public DbToCSV(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }    


    /// <summary>
    /// Writes the database tables to csv files.
    /// </summary>
    public void WriteAllToCSV()
    {
        using(var scope = _scopeFactory.CreateScope())
        using(var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!)
        {
            WriteTableToCSV<Pokemon, PokemonCSVMap>(@"pokemon.csv", dbContext.Pokemon);
            WriteTableToCSV<PkmnType, PkmnTypeCSVMap>(@"pkmn_type.csv", dbContext.PkmnType);
            WriteTableToCSV<BaseStats, BaseStatsCSVMap>(@"base_stats.csv", dbContext.BaseStats);
            WriteTableToCSV<Ability, AbilityCSVMap>(@"ability.csv", dbContext.Ability);
            WriteTableToCSV<Move, MoveCSVMap>(@"move.csv", dbContext.Move);
            WriteTableToCSV<DamageClass, DamageClassCSVMap>(@"damage_class.csv", dbContext.DamageClass);
            WriteTableToCSV<MoveEffect, MoveEffectCSVMap>(@"move_effect.csv", dbContext.MoveEffect);
            WriteTableToCSV<Gender, GenderCSVMap>(@"gender.csv", dbContext.Gender);
            WriteTableToCSV<Item, ItemCSVMap>(@"item.csv", dbContext.Item);
            WriteTableToCSV<Nature, NatureCSVMap>(@"nature.csv", dbContext.Nature);

            // Join Tables
            WriteTableToCSV<PokemonPkmnType, PokemonPkmnTypeCSVMap>(@"pokemon_pkmn_type.csv", dbContext.PokemonPkmnType);
            WriteTableToCSV<PokemonMove, PokemonMoveCSVMap>(@"pokemon_move.csv", dbContext.PokemonMove);
            WriteTableToCSV<PokemonAbility, PokemonAbilityCSVMap>(@"pokemon_ability.csv", dbContext.PokemonAbility);
            WriteTableToCSV<PokemonGender, PokemonGenderCSVMap>(@"pokemon_move.csv", dbContext.PokemonGender);
        }
    }


    /// <summary>
    /// Writes the data contained within the provided DbSet to a file with the name provided.
    /// </summary>
    /// <typeparam name="T">The type of object within the DbSet</typeparam>
    /// <typeparam name="M">The CSV class map type associated with T</typeparam>
    /// <param name="filename"></param>
    private static void WriteTableToCSV<T, M>(string filename, DbSet<T> dbset) 
        where M : ClassMap<T>
        where T : class
    {
        string path = Path.Join(WriteDir, filename);

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var streamWriter = new StreamWriter(path))
        using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
        {
            var records = dbset.ToList();
            csvWriter.Context.RegisterClassMap<M>();
            csvWriter.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }
}