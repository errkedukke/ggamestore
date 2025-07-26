using Gamestore.Application.Features.Genres.Commands.CreateGenre;
using Gamestore.Application.Features.Genres.Commands.DeleteGenre;
using Gamestore.Application.Features.Genres.Commands.UpdateGenre;
using Gamestore.Application.Features.Genres.Queries;
using Gamestore.Application.Features.Genres.Queries.GetGenre;
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
    public async Task<ActionResult<List<GenreDto>>> GetGenres()
    {
        var response = await _mediator.Send(new GetGenresQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenreDto>> GetGenre(Guid id)
    {
        var response = await _mediator.Send(new GetGenreQuery(id));
        return response != null ? Ok(response) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateGenre(CreateGenreCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetGenre), new { id = response }, null);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGenre(Guid id, UpdateGenreCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGenre(Guid id)
    {
        await _mediator.Send(new DeleteGenreCommand { Id = id });
        return NoContent();
    }
}
