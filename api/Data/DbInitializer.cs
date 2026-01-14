using System.Globalization;
using CsvHelper;
using api.Models.Static;
using api.Mappers.CSVClassMaps;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration;


namespace api.Data;

public class DbInitializer : IDbInitializer
{
    private const string SeedDir = @"Data\SeedData";
    private readonly IServiceScopeFactory _scopeFactory;

    public DbInitializer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }   



    /// <summary>
    /// Populates the database with records from the seed data csv files.
    /// </summary>
    public void SeedAll()
    {
        using(var scope = _scopeFactory.CreateScope())
        using(var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!)
        {
            ClearTables(dbContext);

            AddRecords<Pokemon, PokemonCSVMap>(@"pokemon.csv", dbContext.Pokemon);
            AddRecords<PkmnType, PkmnTypeCSVMap>(@"pkmn_type.csv", dbContext.PkmnType);
            AddRecords<BaseStats, BaseStatsCSVMap>(@"base_stats.csv", dbContext.BaseStats);
            AddRecords<Ability, AbilityCSVMap>(@"ability.csv", dbContext.Ability);
            AddRecords<Gender, GenderCSVMap>(@"gender.csv", dbContext.Gender);
            AddRecords<Move, MoveCSVMap>(@"move.csv", dbContext.Move);
            AddRecords<MoveEffect, MoveEffectCSVMap>(@"move_effect.csv", dbContext.MoveEffect); // MOVE EFFECTS ARE MISSING FOR SOME NEWER MOVES IN SEED DATA
            AddRecords<DamageClass, DamageClassCSVMap>(@"damage_class.csv", dbContext.DamageClass);
            AddRecords<Item, ItemCSVMap>(@"item.csv", dbContext.Item);
            AddRecords<Nature, NatureCSVMap>(@"nature.csv", dbContext.Nature);

            AddRecords<PokemonPkmnType, PokemonPkmnTypeCSVMap>(@"pokemon_pkmn_type.csv", dbContext.PokemonPkmnType);
            AddRecords<PokemonMove, PokemonMoveCSVMap>(@"pokemon_move.csv", dbContext.PokemonMove);
            AddRecords<PokemonAbility, PokemonAbilityCSVMap>(@"pokemon_ability.csv", dbContext.PokemonAbility);
            AddRecords<PokemonGender, PokemonGenderCSVMap>(@"pokemon_gender.csv", dbContext.PokemonGender);

            dbContext.SaveChanges();
        }
    }


    private void ClearTables(ApplicationDbContext context)
    {
        context.Pokemon.ExecuteDelete();
        context.PkmnType.ExecuteDelete();
        context.BaseStats.ExecuteDelete();
        context.Ability.ExecuteDelete();
        context.Move.ExecuteDelete();
        context.DamageClass.ExecuteDelete();
        context.MoveEffect.ExecuteDelete();
        context.Gender.ExecuteDelete();
        context.Item.ExecuteDelete();
        context.Nature.ExecuteDelete();

        context.PokemonPkmnType.ExecuteDelete();
        context.PokemonMove.ExecuteDelete();
        context.PokemonAbility.ExecuteDelete();
        context.PokemonGender.ExecuteDelete();
    }


    /// <summary>
    /// Reads the data from the file with provided name and adds its data to the provided DbSet.
    /// </summary>
    /// <typeparam name="T">The type of object within the DbSet.</typeparam>
    /// <typeparam name="M">The CSV class map type associated with T.</typeparam>
    /// <param name="filename">The filename containing the records.</param>
    /// <param name="dbSet">The DbSet to add entries to.</param>
    private void AddRecords<T, M>(string filename, DbSet<T> dbSet) 
        where M : ClassMap<T>
        where T : class
    {
        using (var streamReader = new StreamReader(Path.Join(SeedDir, filename)))
        using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
        {
            csvReader.Context.RegisterClassMap<M>();
            var records = csvReader.GetRecords<T>().ToArray();
            dbSet.AddRange(records);
        }
    }
}