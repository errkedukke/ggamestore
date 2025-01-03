﻿using Gamestore.API.Controllers;
using Gamestore.Application.Exceptions;
using Gamestore.Application.Features.Categories.Commands.CreateCategory;
using Gamestore.Application.Features.Categories.Commands.DeleteCategory;
using Gamestore.Application.Features.Categories.Commands.UpdateCategory;
using Gamestore.Application.Features.Categories.Queries;
using Gamestore.Application.Features.Categories.Queries.GetCategories;
using Gamestore.Application.Features.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Gamestore.Tests.API;

internal class CategoriesControllerTests
{
    internal required Mock<ILogger<CategoriesController>> _mockLogger;
    internal required Mock<IMediator> _mockMediator;
    internal required CategoriesController _controller;

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<CategoriesController>>();
        _mockMediator = new Mock<IMediator>();
        _controller = new CategoriesController(_mockLogger.Object, _mockMediator.Object);
    }

    [Test]
    public async Task GetCategories_ShouldReturnOkWithCategories()
    {
        // Arrange
        var categories = new List<CategoryDto>
        {
            new CategoryDto { CategoryName = "Category1", Description = "Description1" },
            new CategoryDto { CategoryName = "Category2", Description = "Description2" }
        };

        _mockMediator.Setup(m => m.Send(It.IsAny<GetCategoriesQuery>(), default))
            .ReturnsAsync(categories);

        // Act
        var result = await _controller.GetCategories();

        // Assert
        Assert.Multiple(() =>
        {
            var okResult = result.Result as OkObjectResult;

            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult!.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
            Assert.That(okResult.Value, Is.EqualTo(categories));
        });
    }

    [Test]
    public async Task GetCategories_ShouldReturnEmptyList_WhenNoCategoriesExist()
    {
        // Arrange
        var emptyList = new List<CategoryDto>();
        _mockMediator.Setup(m => m.Send(It.IsAny<GetCategoriesQuery>(), default))
                     .ReturnsAsync(emptyList);

        // Act
        var result = await _controller.GetCategories();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
            Assert.That(okResult.Value, Is.EqualTo(emptyList));
        });
    }

    [Test]
    public void GetCategory_ShouldReturnNotFound_WhenCategoryDoesNotExist()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        _mockMediator.Setup(m => m.Send(It.Is<GetCategoryQuery>(q => q.Id == categoryId), default))
            .ReturnsAsync((CategoryDto)null!);

        // Act & Assert
        Assert.Multiple(() =>
        {
            var exception = Assert.ThrowsAsync<NotFoundException>(() => _controller.GetCategory(categoryId));

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception!.Message, Is.EqualTo($"{nameof(GetCategoryQuery)} ({categoryId}) was not found"));
            Assert.That(exception.InnerException, Is.Null);
        });
    }

    [Test]
    public async Task GetCategory_ShouldLogInformation_WhenCategoryIsRetrieved()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var category = new CategoryDto { CategoryName = "LoggedCategory", Description = "ForLogging" };
        _mockMediator.Setup(m => m.Send(It.Is<GetCategoryQuery>(q => q.Id == categoryId), default))
                     .ReturnsAsync(category);

        // Act
        var result = await _controller.GetCategory(categoryId);

        // Assert
        _mockLogger.Verify(logger => logger.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((o, t) => o.ToString().Contains("Category retrieved")),
            It.IsAny<Exception>(),
            It.Is<Func<It.IsAnyType, Exception, string>>((o, t) => true)!),
            Times.Once);

        Assert.Multiple(() =>
        {
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult!.Value, Is.EqualTo(category));
        });
    }

    [Test]
    public async Task GetCategory_ShouldReturnOkWithCategory()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var category = new CategoryDto { CategoryName = "TestCategory", Description = "TestDescription" };
        _mockMediator.Setup(m => m.Send(It.Is<GetCategoryQuery>(q => q.Id == categoryId), default))
            .ReturnsAsync(category);

        // Act
        var result = await _controller.GetCategory(categoryId);

        // Assert
        Assert.Multiple(() =>
        {
            var okResult = result.Result as OkObjectResult;

            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult!.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
            Assert.That(okResult.Value, Is.EqualTo(category));
        });
    }

    [Test]
    public async Task Post_ShouldReturnCreatedAtAction()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var command = new CreateCategoryCommand { CategoryName = "NewCategory" };
        _mockMediator.Setup(m => m.Send(command, default))
            .ReturnsAsync(categoryId);

        // Act
        var result = await _controller.Post(command);

        // Assert
        Assert.Multiple(() =>
        {
            var createdResult = result.Result as CreatedAtActionResult;

            Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
            Assert.That(createdResult, Is.Not.Null);
            Assert.That(createdResult!.StatusCode, Is.EqualTo(StatusCodes.Status201Created));
            Assert.That(createdResult.ActionName, Is.EqualTo("GetCategory"));
        });
    }

    [Test]
    public async Task Post_ShouldReturnInternalServerError_WhenMediatorThrowsException()
    {
        // Arrange
        var command = new CreateCategoryCommand { CategoryName = "FaultyCategory" };
        _mockMediator.Setup(m => m.Send(command, default)).ThrowsAsync(new Exception("An error occurred"));

        // Act
        var result = await _controller.Post(command);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Result, Is.InstanceOf<ObjectResult>());
            var objectResult = result.Result as ObjectResult;
            Assert.That(objectResult, Is.Not.Null);
            Assert.That(objectResult!.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
        });
    }

    [Test]
    public async Task Put_ShouldReturnNotFound_WhenCategoryToUpdateDoesNotExist()
    {
        // Arrange
        var command = new UpdateCategoryCommand { CategoryName = "NonExistentCategory" };
        _mockMediator.Setup(m => m.Send(command, default)).ThrowsAsync(new KeyNotFoundException("Category not found"));

        // Act
        var result = await _controller.Put(command);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        });
    }

    [Test]
    public async Task Put_ShouldReturnNoContent()
    {
        // Arrange
        var command = new UpdateCategoryCommand { CategoryName = "UpdatedCategory", Description = "UpdateDescription" };
        _mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync(Unit.Value);

        // Act
        var result = await _controller.Put(command);

        // Assert
        Assert.Multiple(() =>
        {
            var noContentResult = result as NoContentResult;

            Assert.That(result, Is.InstanceOf<NoContentResult>());
            Assert.That(noContentResult!.StatusCode, Is.EqualTo(StatusCodes.Status204NoContent));
        });
    }

    [Test]
    public async Task Delete_ShouldReturnNoContent()
    {
        // Arrange
        var command = new DeleteCategoryCommand { Id = Guid.NewGuid() };
        _mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync(Unit.Value);

        // Act
        var result = await _controller.Delete(command);

        // Assert
        Assert.Multiple(() =>
        {
            var noContentResult = result as NoContentResult;

            Assert.That(result, Is.InstanceOf<NoContentResult>());
            Assert.That(noContentResult!.StatusCode, Is.EqualTo(StatusCodes.Status204NoContent));
        });
    }

    [Test]
    public void Delete_ShouldReturnNotFound_WhenCategoryToDeleteDoesNotExist()
    {
        // Arrange
        var command = new DeleteCategoryCommand { Id = Guid.NewGuid() };
        _mockMediator.Setup(m => m.Send(command, default))
            .ThrowsAsync(new NotFoundException(nameof(command), command.Id));

        // Act & Assert
        Assert.Multiple(() =>
        {
            var exception = Assert.ThrowsAsync<NotFoundException>(() => _controller.Delete(command));

            Assert.That(exception, Is.Not.Null);
            Assert.That(exception!.Message, Is.EqualTo($"{nameof(command)} ({command.Id}) was not found"));
            Assert.That(exception.InnerException, Is.Null);
        });
    }
}
