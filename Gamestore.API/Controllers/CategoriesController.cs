using Gamestore.Application.Features.Categories.Commands.CreateCategory;
using Gamestore.Application.Features.Categories.Commands.DeleteCategory;
using Gamestore.Application.Features.Categories.Commands.UpdateCategory;
using Gamestore.Application.Features.Categories.Queries;
using Gamestore.Application.Features.Categories.Queries.GetCategories;
using Gamestore.Application.Features.Categories.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ILogger<CategoriesController> _logger;
    private readonly IMediator _mediator;

    public CategoriesController(ILogger<CategoriesController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CategoryDto>>> GetCategories()
    {
        var request = new GetCategoriesQuery();
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
    {
        var request = new GetCategoryQuery(id);
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> Post(CreateCategoryCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCategory), new { id = response });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(UpdateCategoryCommand command)
    {
        var response = await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(DeleteCategoryCommand request)
    {
        var response = await _mediator.Send(request);
        return NoContent();
    }
}
