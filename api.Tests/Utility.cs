using api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace api.Tests;

public static class Utility
{
    public static ApplicationDbContext CreateTestDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;

        var testDbContext = new ApplicationDbContext(options);

        testDbContext.Database.EnsureDeleted();
        testDbContext.Database.EnsureCreated();

        return testDbContext;
    }


    public static void AddTestData(ApplicationDbContext context)
    {
        context.Ability.AddRange(TestData.GetAbilities());
        context.BaseStats.AddRange(TestData.GetBaseStats());
        context.DamageClass.AddRange(TestData.GetDamageClasses());
        context.Gender.AddRange(TestData.GetGenders());
        context.Item.AddRange(TestData.GetItems());
        context.Move.AddRange(TestData.GetMoves());
        context.MoveEffect.AddRange(TestData.GetMoveEffects());
        context.Nature.AddRange(TestData.GetNatures());
        context.PkmnType.AddRange(TestData.GetPkmnTypes());
        context.Pokemon.AddRange(TestData.GetPokemon());

        context.PokemonAbility.AddRange(TestData.GetPokemonAbilitys());
        context.PokemonGender.AddRange(TestData.GetPokemonGenders());
        context.PokemonMove.AddRange(TestData.GetPokemonMoves());
        context.PokemonPkmnType.AddRange(TestData.GetPokemonPkmnTypes());

        context.SaveChanges();
    }
}