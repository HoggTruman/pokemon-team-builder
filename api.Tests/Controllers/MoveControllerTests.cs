using api.Controllers;
using api.Interfaces.Repository;
using api.Models.Static;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;

namespace api.Tests.Controllers;

public class MoveControllerTests
{
    private readonly Mock<IMoveRepository> _repositoryStub;

    public MoveControllerTests()
    {
        _repositoryStub = new Mock<IMoveRepository>();
    }

    private readonly List<Move> testData = 
    [
        new()
        {

        },
        new()
        {

        }
    ];




    [Fact]
    public void GetAll_WithNoMoves_ReturnsOk()
    {
        // Arrange
        const int ExpectedStatusCode = 200;

        _repositoryStub.Setup(repo => repo.GetAll())
            .Returns(new List<Move>());

        var controller = new MoveController(_repositoryStub.Object);

        // Act
        var result = controller.GetAll();
        var statusCodeResult = (IStatusCodeActionResult)result;

        // Assert
        result.Should().NotBeNull();
        statusCodeResult.StatusCode.Should().Be(ExpectedStatusCode);
    }


    [Fact]
    public void GetAll_WithMoves_ReturnsOk()
    {
        // Arrange
        const int ExpectedStatusCode = 200;

        _repositoryStub.Setup(repo => repo.GetAll())
            .Returns(testData);

        var controller = new MoveController(_repositoryStub.Object);

        // Act
        var result = controller.GetAll();
        var statusCodeResult = (IStatusCodeActionResult)result;

        // Assert
        result.Should().NotBeNull();
        statusCodeResult.StatusCode.Should().Be(ExpectedStatusCode);
    }


    [Fact]
    public void GetMovesByPokemonId_WithMatches_ReturnsOk()
    {
        // Arrange 
        const int ExpectedStatusCode = 200;
        const int testPokemonId = 1;

        _repositoryStub.Setup(repo => repo.GetMovesByPokemonId(testPokemonId))
            .Returns(testData);

        var controller = new MoveController(_repositoryStub.Object);

        // Act
        var result = controller.GetMovesByPokemonId(testPokemonId);
        var statusCodeResult = (IStatusCodeActionResult)result;

        // Assert
        result.Should().NotBeNull();
        statusCodeResult.StatusCode.Should().Be(ExpectedStatusCode);
    }


    [Fact]
    public void GetMovesByPokemonId_WithoutMatches_ReturnsNotFound()
    {
        // Arrange 
        const int ExpectedStatusCode = 404;
        const int testPokemonId = 1;

        _repositoryStub.Setup(repo => repo.GetMovesByPokemonId(testPokemonId))
            .Returns((List<Move>?)null);

        var controller = new MoveController(_repositoryStub.Object);

        // Act
        var result = controller.GetMovesByPokemonId(testPokemonId);
        var statusCodeResult = (IStatusCodeActionResult)result;

        // Assert
        result.Should().NotBeNull();
        statusCodeResult.StatusCode.Should().Be(ExpectedStatusCode);
    }
}