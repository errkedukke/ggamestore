using Gamestore.Application.Features.Categories.Commands.CreateCategory;
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
    public async Task<List<CategoryDto>> GetCategories()
    {
        var request = new GetCategoriesQuery();
        var response = await _mediator.Send(request);

        return response;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
    {
        var request = new GetCategoryQuery(id);
        var response = await _mediator.Send(request);

        return response;
    }

    [HttpPost]
    public async Task<ActionResult> Post(CreateCategoryCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCategory), new { Id = response });
    }
}
