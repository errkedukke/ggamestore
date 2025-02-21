using Gamestore.API.Controllers;
using Gamestore.Application.Features.Game.Queries;
using Gamestore.Application.Features.Game.Queries.GetGame;
using Gamestore.Application.Features.Game.Queries.GetGames;
using Gamestore.Application.Features.Games.Commands.CreateGame;
using Gamestore.Application.Features.Games.Commands.DeleteGame;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Gamestore.Tests.API;

[TestFixture]
public class GamesControllerTests
{
    private Mock<ILogger<GamesController>> _loggerMock;
    private Mock<IMediator> _mediatorMock;
    private GamesController _controller;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<GamesController>>();
        _mediatorMock = new Mock<IMediator>();
        _controller = new GamesController(_loggerMock.Object, _mediatorMock.Object);
    }

    [Test]
    public async Task GetGames_ReturnsOkResult_WithListOfGames()
    {
        // Arrange
        var games = new List<GameDto> { new GameDto { Name = "Test Game", Price = 59.99M } };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetGamesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(games);

        // Act
        var result = await _controller.GetGames();

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.Value, Is.InstanceOf<List<GameDto>>());
    }

    [Test]
    public async Task GetGame_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var gameId = Guid.NewGuid();
        var game = new GameDto { Name = "Test Game", Price = 59.99M };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetGameQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(game);

        // Act
        var result = await _controller.GetGame(gameId);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
    }

    [Test]
    public async Task GetGame_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetGameQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((GameDto)null);

        // Act
        var result = await _controller.GetGame(Guid.NewGuid());

        // Assert
        Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public async Task CreateGame_ValidCommand_ReturnsCreatedAtAction()
    {
        // Arrange
        var command = new CreateGameCommand { Name = "New Game", Price = 49.99M, CategoryId = Guid.NewGuid(), GenreId = Guid.NewGuid() };
        var newGameId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateGameCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(newGameId);

        // Act
        var result = await _controller.CreateGame(command);

        // Assert
        Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
    }

    [Test]
    public async Task DeleteGame_ExistingId_ReturnsNoContent()
    {
        // Arrange
        var gameId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteGameCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value);

        // Act
        var result = await _controller.DeleteGame(gameId);

        // Assert
        Assert.That(result, Is.InstanceOf<NoContentResult>());
    }
}
