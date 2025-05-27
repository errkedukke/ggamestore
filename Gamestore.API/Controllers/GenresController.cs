using Gamestore.Application.Features.Genres.Queries;
using Gamestore.Application.Features.Genres.Queries.GetGenres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly ILogger<GenresController> _logger;
    private readonly IMediator _mediator;

    public GenresController(ILogger<GenresController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenreDto>> GetGenres()
    {
        var resposne = await _mediator.Send(new GetGenresQuery());
        return resposne != null ? Ok(resposne) : NotFound();
    }
}
