using Gamestore.API.Controllers;
using Gamestore.Application.Features.Comments.Commands.CreateComment;
using Gamestore.Application.Features.Comments.Commands.DeleteComment;
using Gamestore.Application.Features.Comments.Queries;
using Gamestore.Application.Features.Comments.Queries.GetComment;
using Gamestore.Application.Features.Comments.Queries.GetComments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Gamestore.Tests.API;

[TestFixture]
public class CommentsControllerTests
{
    private Mock<ILogger<CommentsController>> _loggerMock;
    private Mock<IMediator> _mediatorMock;
    private CommentsController _controller;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<CommentsController>>();
        _mediatorMock = new Mock<IMediator>();
        _controller = new CommentsController(_loggerMock.Object, _mediatorMock.Object);
    }

    [Test]
    public async Task GetComments_ReturnsOkResult_WithListOfComments()
    {
        // Arrange
        var comments = new List<CommentDto> { new CommentDto { Body = "Test Comment", AuthorId = Guid.NewGuid() } };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCommentsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(comments);

        // Act
        var result = await _controller.GetComments();

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.Value, Is.InstanceOf<List<CommentDto>>());
    }

    [Test]
    public async Task GetComment_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var commentId = Guid.NewGuid();
        var comment = new CommentDto { Body = "Test Comment", AuthorId = Guid.NewGuid() };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCommentQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(comment);

        // Act
        var result = await _controller.GetComment(commentId);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
    }

    [Test]
    public async Task GetComment_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCommentQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((CommentDto)null);

        // Act
        var result = await _controller.GetComment(Guid.NewGuid());

        // Assert
        Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public async Task CreateComment_ValidCommand_ReturnsCreatedAtAction()
    {
        // Arrange
        var command = new CreateCommentCommand { Body = "New Comment", AuthorId = Guid.NewGuid(), GameId = Guid.NewGuid() };
        var newCommentId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCommentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(newCommentId);

        // Act
        var result = await _controller.CreateComment(command);

        // Assert
        Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
    }

    [Test]
    public async Task DeleteComment_ExistingId_ReturnsNoContent()
    {
        // Arrange
        var commentId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCommentCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value);

        // Act
        var result = await _controller.DeleteComment(commentId);

        // Assert
        Assert.That(result, Is.InstanceOf<NoContentResult>());
    }
}
