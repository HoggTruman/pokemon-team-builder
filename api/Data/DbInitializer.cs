using System.Globalization;
using CsvHelper;
using api.Models;
using api.Mappers.CSVClassMaps;


namespace api.Data;

public class DbInitializer
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DbInitializer(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }


    public void SeedAll()
    {
        using(var scope = _scopeFactory.CreateScope())
        using(var context = scope.ServiceProvider.GetService<ApplicationDbContext>()!)
        {
            AddPokemon(context);
            AddPkmnType(context);
            AddBaseStats(context);
            AddAbility(context);
            AddGender(context);
            AddMove(context);
            // MOVE EFFECTS ARE MISSING FOR SOME NEWER MOVES IN SEED DATA
            AddMoveEffect(context);
            AddDamageClass(context);

            AddPokemonPkmnType(context);
            AddPokemonMove(context);
            AddPokemonAbility(context);
            AddPokemonGender(context);
            



            context.SaveChanges();

        }
    }


    private void AddPokemon(ApplicationDbContext context)
    {
        if (!context.Pokemon.Any())
            {
                using (var reader = new StreamReader(@"Data\SeedData\pokemon.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<PokemonCSVMap>();
                    var records = csv.GetRecords<Pokemon>().ToArray();
                    context.Pokemon.AddRange(records);  
                }
            }
    }


    private void AddPkmnType(ApplicationDbContext context)
    {
        if (!context.PkmnType.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\types.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PkmnTypeCSVMap>();
                var records = csv.GetRecords<PkmnType>().ToArray();
                context.PkmnType.AddRange(records);
            }
        }
    }


    private void AddBaseStats(ApplicationDbContext context)
    {
        if (!context.BaseStats.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\pokemon_stats.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = new List<BaseStats>();

                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    var record = records.Find(x => x.PokemonId == csv.GetField<int>("pokemon_id"));
                    if (record == null)
                    {
                        record = new BaseStats()
                        {
                            PokemonId = csv.GetField<int>("pokemon_id")
                        };

                        records.Add(record);
                    }

                    switch (csv.GetField<int>("stat_id"))
                    {
                        case 1:
                            record.HP = csv.GetField<int>("base_stat");
                            break;
                        case 2:
                            record.Attack = csv.GetField<int>("base_stat");
                            break;
                        case 3:
                            record.Defense = csv.GetField<int>("base_stat");
                            break;
                        case 4:
                            record.SpecialAttack = csv.GetField<int>("base_stat");
                            break;
                        case 5:
                            record.SpecialDefense = csv.GetField<int>("base_stat");
                            break;
                        case 6:
                            record.Speed = csv.GetField<int>("base_stat");
                            break;                        
                    }
                }
                context.BaseStats.AddRange(records);
            }  
        }
    }


    private void AddAbility(ApplicationDbContext context)
    {
        if (!context.Ability.Any())
        {
            var abilityRecords = new List<Ability>();

            // Add Main series Ability name and Id
            using (var reader = new StreamReader(@"Data\SeedData\abilities.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<AbilityCSVMap>();

                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    if (csv.GetField<int>("is_main_series") == 1)
                    {
                        abilityRecords.Add(csv.GetRecord<Ability>());
                    }
                }
            }

            // Add FlavorText to each Ability
            using (var reader = new StreamReader(@"Data\SeedData\ability_flavor_text.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                const int ENGLISH_LANGUAGE_ID = 9;
                
                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    if (csv.GetField<int>("language_id") == ENGLISH_LANGUAGE_ID)
                    {
                        var record = abilityRecords.Find(x => x.Id == csv.GetField<int>("ability_id"));

                        if (record != null) 
                        {
                            record.FlavorText = csv.GetField<string>("flavor_text");
                        }
                    }
                }
            }

            context.Ability.AddRange(abilityRecords);            
        }
    }


    private void AddMove(ApplicationDbContext context)
    {
        if (!context.Move.Any())
            {
                using (var reader = new StreamReader(@"Data\SeedData\moves.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<MoveCSVMap>();
                    var records = csv.GetRecords<Move>().ToArray();
                    context.Move.AddRange(records);
                }
            }
    }


    private void AddDamageClass(ApplicationDbContext context)
    {
        if (!context.DamageClass.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\move_damage_classes.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<DamageClassCSVMap>();
                var records = csv.GetRecords<DamageClass>().ToArray();
                context.DamageClass.AddRange(records);
            }
        }
    }


    private void AddMoveEffect(ApplicationDbContext context)
    {
        if (!context.MoveEffect.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\move_effect_prose.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<MoveEffectCSVMap>();
                var records = csv.GetRecords<MoveEffect>().ToArray();
                context.MoveEffect.AddRange(records);
            }     
        }
    }


    private void AddGender(ApplicationDbContext context)
    {
        if (!context.Gender.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\genders.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<GenderCSVMap>();
                var records = csv.GetRecords<Gender>().ToArray();
                context.Gender.AddRange(records); 
            }                     
        }

    }




    private void AddPokemonPkmnType(ApplicationDbContext context)
    {
        if (!context.PokemonPkmnType.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\pokemon_types.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PokemonPkmnTypeCSVMap>();
                var records = csv.GetRecords<PokemonPkmnType>().ToArray();
                context.PokemonPkmnType.AddRange(records);
            }
        }
    }


    private void AddPokemonMove(ApplicationDbContext context)
    {
        if (!context.PokemonMove.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\pokemon_moves.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PokemonMoveCSVMap>();
                var records = csv.GetRecords<PokemonMove>().ToArray();
                context.PokemonMove.AddRange(records);
            }     
        }
    }


    private void AddPokemonAbility(ApplicationDbContext context)
    {
        if (!context.PokemonAbility.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\pokemon_abilities.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PokemonAbilityCSVMap>();

                var records = new List<PokemonAbility>();

                csv.Read();
                csv.ReadHeader();

                while(csv.Read())
                {
                    var record = csv.GetRecord<PokemonAbility>();

                    if (records.Find(x => x.PokemonId == record.PokemonId && x.AbilityId == record.AbilityId) == null)
                    {
                        records.Add(record);
                    }
                }

                context.PokemonAbility.AddRange(records);
            }            
        }
    }


    private void AddPokemonGender(ApplicationDbContext context)
    {
        if (!context.PokemonGender.Any())
        {
            using (var reader = new StreamReader(@"Data\SeedData\pokemon_species.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                const int FEMALE_ID = 1;
                const int MALE_ID = 2;
                const int GENDERLESS_ID = 3;

                var records = new List<PokemonGender>();

                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    switch (csv.GetField<int>("gender_rate"))
                    {
                        case 0:
                            records.Add(
                                new PokemonGender
                                {
                                    PokemonId = csv.GetField<int>("id"),
                                    GenderId = MALE_ID
                                }
                            );
                            break;

                        case 8:
                            records.Add(
                                new PokemonGender
                                {
                                    PokemonId = csv.GetField<int>("id"),
                                    GenderId = FEMALE_ID
                                }
                            );
                            break;

                        case -1:
                            records.Add(
                                new PokemonGender
                                {
                                    PokemonId = csv.GetField<int>("id"),
                                    GenderId = GENDERLESS_ID
                                }
                            );                    
                            break;
                            
                        default:
                            records.Add(
                                new PokemonGender
                                {
                                    PokemonId = csv.GetField<int>("id"),
                                    GenderId = MALE_ID
                                }
                            );
                            records.Add(
                                new PokemonGender
                                {
                                    PokemonId = csv.GetField<int>("id"),
                                    GenderId = FEMALE_ID
                                }
                            );
                            break;                        
                    }
                }

                context.PokemonGender.AddRange(records);
            }
        }
    }
    

}