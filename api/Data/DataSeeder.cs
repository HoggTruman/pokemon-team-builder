using System.Globalization;
using api.Mappers.CSVClassMaps;
using api.Models;
using CsvHelper;
using Microsoft.EntityFrameworkCore;



namespace api.Data;



public class DataSeeder
{
    private readonly ModelBuilder _modelBuilder;

    public DataSeeder(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }


    public void SeedAll()
    {
        SeedPokemon();
        SeedPkmnType();
        SeedPokemonPkmnType();
        SeedBaseStats();
        SeedAbility();
        SeedPokemonAbility();
        SeedGender();
        SeedPokemonGender();
    }  




    private void SeedPokemon()
    {
        using (var reader = new StreamReader(@"Data\SeedData\pokemon.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PokemonCSVMap>();
            var records = csv.GetRecords<Pokemon>().ToArray();
            _modelBuilder.Entity<Pokemon>().HasData(records);
        }
    }




    private void SeedPkmnType()
    {
        using (var reader = new StreamReader(@"Data\SeedData\types.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PkmnTypeCSVMap>();
            var records = csv.GetRecords<PkmnType>().ToArray();
            _modelBuilder.Entity<PkmnType>().HasData(records);
        }
    }




    private void SeedPokemonPkmnType()
    {
        using (var reader = new StreamReader(@"Data\SeedData\pokemon_types.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<PokemonPkmnTypeCSVMap>();
            var records = csv.GetRecords<PokemonPkmnType>().ToArray();
            _modelBuilder.Entity<PokemonPkmnType>().HasData(records);
        }
    }




    private void SeedBaseStats()
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
            _modelBuilder.Entity<BaseStats>().HasData(records);
        }        
    }




    private void SeedAbility()
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

        _modelBuilder.Entity<Ability>().HasData(abilityRecords);
    }        




    private void SeedPokemonAbility()
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

            _modelBuilder.Entity<PokemonAbility>().HasData(records);
        }
    }




    private void SeedGender()
    {
        using (var reader = new StreamReader(@"Data\SeedData\genders.csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<GenderCSVMap>();
            var records = csv.GetRecords<Gender>().ToArray();
            _modelBuilder.Entity<Gender>().HasData(records);
        }
    }




    private void SeedPokemonGender()
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

            _modelBuilder.Entity<PokemonGender>().HasData(records);
        }
    }
    
}