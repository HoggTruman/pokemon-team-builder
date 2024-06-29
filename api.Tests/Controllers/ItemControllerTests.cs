using api.Interfaces.Repository;
using api.Models.Static;
using api.Controllers;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace api.Tests.Controllers;

public class ItemControllerTests
{
    private readonly Mock<IItemRepository> _repositoryStub;

    public ItemControllerTests()
    {
        _repositoryStub = new Mock<IItemRepository>();
    }

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
    public void GetAll_WithItemsInRepo_ReturnsOk()
    {
        // Arrange
        const int ExpectedStatusCode = 200;

        _repositoryStub.Setup(repo => repo.GetAll()).Returns(testItems);
        var itemController = new ItemController(_repositoryStub.Object);

        // Act 
        var result = itemController.GetAll();
        var statusCodeResult = (IStatusCodeActionResult)result;
        

        // Assert
        result.Should().NotBeNull();
        statusCodeResult.StatusCode.Should().Be(ExpectedStatusCode);
    }


    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void GetById_WithIdMatchingItem_ReturnsOk(int testId)
    {
        // Arrange
        const int ExpectedStatusCode = 200;

        _repositoryStub.Setup(repo => repo.GetById(testId))
            .Returns(testItems.FirstOrDefault(x => x.Id == testId));
        var itemController = new ItemController(_repositoryStub.Object);        
        
        // Act
        var result = itemController.GetById(testId);
        var statusCodeResult = (IStatusCodeActionResult)result;

        // Assert
        result.Should().NotBeNull();
        statusCodeResult.StatusCode.Should().Be(ExpectedStatusCode);
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1000)]
    public void GetById_WithIdNotMatchingItem_ReturnsNotFound(int testId)
    {
        // Arrange
        const int ExpectedStatusCode = 404;

        _repositoryStub.Setup(repo => repo.GetById(testId))
            .Returns((Item?)null);
        var itemController = new ItemController(_repositoryStub.Object);        
        
        // Act
        var result = itemController.GetById(testId);
        var statusCodeResult = (IStatusCodeActionResult)result;

        // Assert
        result.Should().NotBeNull();
        statusCodeResult.StatusCode.Should().Be(ExpectedStatusCode);
    }
}