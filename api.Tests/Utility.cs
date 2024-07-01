using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Tests;

public static class Utility
{
    public static ApplicationDbContext CreateTestDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var testDbContext = new ApplicationDbContext(options);
        testDbContext.Database.EnsureCreated();

        return testDbContext;
    }


    public static void AddTestData(ApplicationDbContext context)
    {
        context.Ability.AddRange(TestData.Abilities);
        context.BaseStats.AddRange(TestData.BaseStats);
        context.DamageClass.AddRange(TestData.DamageClasses);
        context.Gender.AddRange(TestData.Genders);
        context.Item.AddRange(TestData.Items);
        context.Move.AddRange(TestData.Moves);
        context.MoveEffect.AddRange(TestData.MoveEffects);
        context.Nature.AddRange(TestData.Natures);
        context.PkmnType.AddRange(TestData.PkmnTypes);
        context.Pokemon.AddRange(TestData.Pokemon);
        
        context.PokemonAbility.AddRange(TestData.PokemonAbility);
        context.PokemonGender.AddRange(TestData.PokemonGender);
        context.PokemonMove.AddRange(TestData.PokemonMove);
        context.PokemonPkmnType.AddRange(TestData.PokemonPkmnType);

        context.SaveChanges();
    }
}