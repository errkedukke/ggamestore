using Gamestore.API.Controllers;
using Gamestore.Application.Features.Categories.Commands.CreateCategory;
using Gamestore.Application.Features.Categories.Commands.DeleteCategory;
using Gamestore.Application.Features.Categories.Queries;
using Gamestore.Application.Features.Categories.Queries.GetCategories;
using Gamestore.Application.Features.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Gamestore.Tests.API;

[TestFixture]
public class CategoriesControllerTests
{
    private Mock<ILogger<CategoriesController>> _loggerMock;
    private Mock<IMediator> _mediatorMock;
    private CategoriesController _controller;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<CategoriesController>>();
        _mediatorMock = new Mock<IMediator>();
        _controller = new CategoriesController(_loggerMock.Object, _mediatorMock.Object);
    }

    [Test]
    public async Task GetCategories_ReturnsOkResult_WithListOfCategories()
    {
        // Arrange
        var categories = new List<CategoryDto> { new CategoryDto { CategoryName = "Test Category", Description = "Test Description" } };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCategoriesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(categories);

        // Act
        var result = await _controller.GetCategories();

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
        var okResult = result.Result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.Value, Is.InstanceOf<List<CategoryDto>>());
    }

    [Test]
    public async Task GetCategory_ExistingId_ReturnsOkResult()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var category = new CategoryDto { CategoryName = "Test Category", Description = "Test Description" };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCategoryQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);

        // Act
        var result = await _controller.GetCategory(categoryId);

        // Assert
        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
    }

    [Test]
    public async Task GetCategory_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCategoryQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((CategoryDto)null);

        // Act
        var result = await _controller.GetCategory(Guid.NewGuid());

        // Assert
        Assert.That(result.Result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public async Task CreateCategory_ValidCommand_ReturnsCreatedAtAction()
    {
        // Arrange
        var command = new CreateCategoryCommand { CategoryName = "New Category", Description = "New Description" };
        var newCategoryId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(newCategoryId);

        // Act
        var result = await _controller.CreateCategory(command);

        // Assert
        Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
    }

    [Test]
    public async Task DeleteCategory_ExistingId_ReturnsNoContent()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value);

        // Act
        var result = await _controller.DeleteCategory(categoryId);

        // Assert
        Assert.That(result, Is.InstanceOf<NoContentResult>());
    }
}

