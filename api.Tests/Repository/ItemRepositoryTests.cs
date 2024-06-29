using api.Models.Static;
using api.Repository;
using FluentAssertions;

namespace api.Tests.Repository;

public class ItemRepositoryTests
{
    private readonly List<Item> testItems =
    [
        new() 
        {
            Id = 1, 
            Identifier = "TestItem1",
            Effect = "TestItem1Effect"
        },
        new() 
        {
            Id = 2, 
            Identifier = "TestItem2",
            Effect = "TestItem2Effect"
        },
        new() 
        {
            Id = 3, 
            Identifier = "TestItem3",
            Effect = "TestItem3Effect"
        },
    ];




    [Fact]
    public void GetAll_WithItemsInDb_ReturnsListOfItems()
    {
        // Arrange
        var testDbContext = Utility.CreateTestDbContext();
        testDbContext.Item.AddRange(testItems);
        testDbContext.SaveChanges();

        var itemRepository = new ItemRepository(testDbContext);

        // Act
        var result = itemRepository.GetAll();

        // Assert
        result.Should().BeEquivalentTo(testItems);
    }


    [Fact]
    public void GetAll_WithoutItemsInDb_ReturnsEmptyList()
    {
        // Arrange
        var expectedResult = new List<Item>();

        var testDbContext = Utility.CreateTestDbContext();

        var itemRepository = new ItemRepository(testDbContext);

        // Act
        var result = itemRepository.GetAll();

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }


    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetById_WithMatchingId_ReturnsItem(int testId)
    {
        // Arrange
        var expectedResult = testItems.FirstOrDefault(x => x.Id == testId);

        var testDbContext = Utility.CreateTestDbContext();
        testDbContext.Item.AddRange(testItems);
        testDbContext.SaveChanges();

        var itemRepository = new ItemRepository(testDbContext);

        // Act
        var result = itemRepository.GetById(testId);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    

    [Theory]
    [InlineData(-1)]
    [InlineData(4)]
    [InlineData(1000)]
    public void GetById_WithoutMatchingId_ReturnsNull(int testId)
    {
        // Arrange
        var testDbContext = Utility.CreateTestDbContext();
        testDbContext.Item.AddRange(testItems);
        testDbContext.SaveChanges();

        var itemRepository = new ItemRepository(testDbContext);

        // Act
        var result = itemRepository.GetById(testId);

        // Assert
        result.Should().BeNull();
    }
}