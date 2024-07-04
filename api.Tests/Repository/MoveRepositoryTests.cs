using api.Data;
using api.Models.Static;
using api.Repository;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit.Abstractions;

namespace api.Tests.Repository;

public class MoveRepositoryTests
{
    private ApplicationDbContext _testDbContext;
    
    public MoveRepositoryTests()
    {
        _testDbContext = Utility.CreateTestDbContext();
        // Utility.AddTestData(_testDbContext);
    }

    [Fact]
    public void GetAll_WithMovesInDb_ReturnsListOfMoves()
    {
        // Arrange
        // var testDbContext = Utility.CreateTestDbContext();
        Utility.AddTestData(_testDbContext);

        var moveRepository = new MoveRepository(_testDbContext);


        // Act
        var result = moveRepository.GetAll();


        // Assert
        result.Should().HaveCount(TestData.Moves.Count);
        foreach (Move testMove in TestData.Moves)
        {
            result.FirstOrDefault(x => x.Id == testMove.Id).Should().NotBeNull();
        }

        // testDbContext.Database.EnsureDeleted();
        // testDbContext.Dispose(); 
    }


    [Fact]
    public void GetAll_WithoutMovesInDb_ReturnsEmptyList()
    {
        // Arrange
        var expectedResult = new List<Move>();
        // var testDbContext = Utility.CreateTestDbContext();
        

        var moveRepository = new MoveRepository(_testDbContext);

        // Act
        var result = moveRepository.GetAll();

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }



    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetMovesByPokemonId_WithMatchingPokemonId_ReturnsListOfMoves(int testPokemonId)
    {
        // Arrange
        var testDbContext = Utility.CreateTestDbContext();
        Utility.AddTestData(testDbContext);
    
        var moveRepository = new MoveRepository(testDbContext);


        // Act
        var result = moveRepository.GetMovesByPokemonId(testPokemonId)!;


        // Assert
        result.Should().NotBeNull();
        
        foreach(Move resultMove in result)
        {
            resultMove.Pokemon.FirstOrDefault(x => x.Id == testPokemonId).Should().NotBeNull();
        }

    }

    

    [Theory]
    [InlineData(-1)]
    [InlineData(1000)]
    public void GetById_WithoutMatchingId_ReturnsNull(int testPokemonId)
    {
        // Arrange
        var testDbContext = Utility.CreateTestDbContext();
        Utility.AddTestData(testDbContext);
        var moveRepository = new MoveRepository(testDbContext);

        // Act
        var result = moveRepository.GetMovesByPokemonId(testPokemonId);

        // Assert
        result.Should().BeNull();
    }
}