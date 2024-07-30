using System.Globalization;
using CsvHelper;
using api.Models.Static;
using api.Mappers.CSVClassMaps;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace api.Data;

public class DbInitializer : IDbInitializer
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DbInitializer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    private const string SeedDir = @"Data\SeedData\";




    public void SeedAll()
    {
        using(var scope = _scopeFactory.CreateScope())
        using(var context = scope.ServiceProvider.GetService<ApplicationDbContext>()!)
        {
            ClearTables(context);

            
            AddPokemon(context);
            AddPkmnType(context);
            AddBaseStats(context);
            AddAbility(context);
            AddGender(context);
            AddMove(context);
            AddMoveEffect(context);
            AddDamageClass(context);
            AddItem(context);
            AddNature(context);

            AddPokemonPkmnType(context);
            AddPokemonMove(context);
            AddPokemonAbility(context);
            AddPokemonGender(context);
            



            context.SaveChanges();
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


    private void AddPokemon(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"pokemon.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PokemonCSVMap>();
            var records = csv.GetRecords<Pokemon>().ToArray();
            context.Pokemon.AddRange(records);
        }
    }


    private void AddPkmnType(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"pkmn_type.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PkmnTypeCSVMap>();
            var records = csv.GetRecords<PkmnType>().ToArray();
            context.PkmnType.AddRange(records);
        }
    }


    private void AddBaseStats(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"base_stats.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<BaseStatsCSVMap>();
            var records = csv.GetRecords<BaseStats>().ToArray();
            context.BaseStats.AddRange(records);
        }
    }


    private void AddAbility(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"ability.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<AbilityCSVMap>();
            var records = csv.GetRecords<Ability>().ToArray();            
            context.Ability.AddRange(records);
        }
    }


    private void AddMove(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"move.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<MoveCSVMap>();
            var records = csv.GetRecords<Move>().ToArray();            
            context.Move.AddRange(records);
        }
    }


    private void AddDamageClass(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"damage_class.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<DamageClassCSVMap>();
            var records = csv.GetRecords<DamageClass>().ToArray();            
            context.DamageClass.AddRange(records);
        }
    }


    private void AddMoveEffect(ApplicationDbContext context)
    {
        // MOVE EFFECTS ARE MISSING FOR SOME NEWER MOVES IN SEED DATA
        using (var reader = new StreamReader(SeedDir + @"move_effect.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<MoveEffectCSVMap>();
            var records = csv.GetRecords<MoveEffect>().ToArray();            
            context.MoveEffect.AddRange(records);
        }     
    }


    private void AddGender(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"gender.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<GenderCSVMap>();
            var records = csv.GetRecords<Gender>().ToArray();            
            context.Gender.AddRange(records); 
        }                     
    }


    private void AddItem(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"item.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<ItemCSVMap>();
            var records = csv.GetRecords<Item>().ToArray();            
            context.Item.AddRange(records);
        }     
    }


    private void AddNature(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"nature.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<NatureCSVMap>();
            var records = csv.GetRecords<Nature>().ToArray();            
            context.Nature.AddRange(records);
        }
    }





    private void AddPokemonPkmnType(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"pokemon_pkmn_type.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PokemonPkmnTypeCSVMap>();
            var records = csv.GetRecords<PokemonPkmnType>().ToArray();            
            context.PokemonPkmnType.AddRange(records);
        }
    }


    private void AddPokemonMove(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"pokemon_move.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PokemonMoveCSVMap>();
            var records = csv.GetRecords<PokemonMove>().ToArray();            
            context.PokemonMove.AddRange(records);
        }     
    }


    private void AddPokemonAbility(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"pokemon_ability.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PokemonAbilityCSVMap>();
            var records = csv.GetRecords<PokemonAbility>().ToArray();            
            context.PokemonAbility.AddRange(records);
        }
    }


    private void AddPokemonGender(ApplicationDbContext context)
    {
        using (var reader = new StreamReader(SeedDir + @"pokemon_gender.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PokemonGenderCSVMap>();
            var records = csv.GetRecords<PokemonGender>().ToArray();            
            context.PokemonGender.AddRange(records);
        }
    }
}