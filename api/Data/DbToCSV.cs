using System.Globalization;
using api.Mappers.CSVClassMaps;
using CsvHelper;

namespace api.Data;

public class DbToCSV
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DbToCSV(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    private const string WriteDir = @"Data\WriteData\";


    public void WriteAllToCSV()
    {
        using(var scope = _scopeFactory.CreateScope())
        using(var context = scope.ServiceProvider.GetService<ApplicationDbContext>()!)
        {
            WritePokemon(context);
            WritePkmnType(context);
            WriteBaseStats(context);
            WriteAbility(context);
            WriteMove(context);
            WriteDamageClass(context);
            WriteMoveEffect(context);
            WriteGender(context);
            WriteItem(context);
            WriteNature(context);

            WritePokemonPkmnType(context);
            WritePokemonMove(context);
            WritePokemonAbility(context);
            WritePokemonGender(context);
        }
    }


    private void WritePokemon(ApplicationDbContext context)
    {
        const string path = WriteDir + @"pokemon.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.Pokemon.ToList();
            csv.Context.RegisterClassMap<PokemonCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WritePkmnType(ApplicationDbContext context)
    {
        const string path = WriteDir + @"pkmn_type.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.PkmnType.ToList();
            csv.Context.RegisterClassMap<PkmnTypeCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WriteBaseStats(ApplicationDbContext context)
    {
        const string path = WriteDir + @"base_stats.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.BaseStats.ToList();
            csv.Context.RegisterClassMap<BaseStatsCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WriteAbility(ApplicationDbContext context)
    {
        const string path = WriteDir + @"ability.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.Ability.ToList();
            csv.Context.RegisterClassMap<AbilityCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WriteMove(ApplicationDbContext context)
    {
        const string path = WriteDir + @"move.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.Move.ToList();
            csv.Context.RegisterClassMap<MoveCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WriteDamageClass(ApplicationDbContext context)
    {
        const string path = WriteDir + @"damage_class.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.DamageClass.ToList();
            csv.Context.RegisterClassMap<DamageClassCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WriteMoveEffect(ApplicationDbContext context)
    {
        const string path = WriteDir + @"move_effect.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.MoveEffect.ToList();
            csv.Context.RegisterClassMap<MoveEffectCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WriteGender(ApplicationDbContext context)
    {
        const string path = WriteDir + @"gender.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.Gender.ToList();
            csv.Context.RegisterClassMap<GenderCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WriteItem(ApplicationDbContext context)
    {
        const string path = WriteDir + @"item.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.Item.ToList();
            csv.Context.RegisterClassMap<ItemCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

        private void WriteNature(ApplicationDbContext context)
    {
        const string path = WriteDir + @"nature.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.Nature.ToList();
            csv.Context.RegisterClassMap<NatureCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }




    private void WritePokemonPkmnType(ApplicationDbContext context)
    {
        const string path = WriteDir + @"pokemon_pkmn_type.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.PokemonPkmnType.ToList();
            csv.Context.RegisterClassMap<PokemonPkmnTypeCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WritePokemonMove(ApplicationDbContext context)
    {
        const string path = WriteDir + @"pokemon_move.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.PokemonMove.ToList();
            csv.Context.RegisterClassMap<PokemonMoveCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WritePokemonAbility(ApplicationDbContext context)
    {
        const string path = WriteDir + @"pokemon_ability.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.PokemonAbility.ToList();
            csv.Context.RegisterClassMap<PokemonAbilityCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

    private void WritePokemonGender(ApplicationDbContext context)
    {
        const string path = WriteDir + @"pokemon_gender.csv";

        if (File.Exists(path))
        {
            Console.WriteLine($"File already exists at {path}");
            return;
        }

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            var records = context.PokemonGender.ToList();
            csv.Context.RegisterClassMap<PokemonGenderCSVMap>();
            csv.WriteRecords(records);
            Console.WriteLine($"File written to {path}");
        }
    }

}