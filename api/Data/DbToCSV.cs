using System.Globalization;
using api.Mappers.CSVClassMaps;
using api.Models;
using CsvHelper;

namespace api.Data;

public class DbToCSV
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DbToCSV(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

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
        const string path = @"Data\WriteData\pokemon.csv";

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
        const string path = @"Data\WriteData\pkmn_type.csv";

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
        const string path = @"Data\WriteData\base_stats.csv";

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
        const string path = @"Data\WriteData\ability.csv";

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
        const string path = @"Data\WriteData\move.csv";

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
        const string path = @"Data\WriteData\damage_class.csv";

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
        const string path = @"Data\WriteData\move_effect.csv";

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
        const string path = @"Data\WriteData\gender.csv";

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
        const string path = @"Data\WriteData\item.csv";

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
        const string path = @"Data\WriteData\nature.csv";

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
        const string path = @"Data\WriteData\pokemon_pkmn_type.csv";

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
        const string path = @"Data\WriteData\pokemon_move.csv";

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
        const string path = @"Data\WriteData\pokemon_ability.csv";

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

    private void WritePokemonGender(ApplicationDbContext context)
    {
        const string path = @"Data\WriteData\pokemon_gender.csv";

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