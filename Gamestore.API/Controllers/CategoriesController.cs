using Gamestore.Application.Features.Categories.Queries;
using Gamestore.Application.Features.Categories.Queries.GetCategories;
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
        var categories = await _mediator.Send(request);

        return categories;
    }
}
