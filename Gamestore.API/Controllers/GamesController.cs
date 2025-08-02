using Gamestore.Application.Features.Game.Queries;
using Gamestore.Application.Features.Game.Queries.GetGame;
using Gamestore.Application.Features.Game.Queries.GetGames;
using Gamestore.Application.Features.Games.Commands.CreateGame;
using Gamestore.Application.Features.Games.Commands.DeleteGame;
using Gamestore.Application.Features.Games.Commands.UpdateGame;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly ILogger<GamesController> _logger;
    private readonly IMediator _mediator;

    public GamesController(ILogger<GamesController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GameDto>>> GetGames([FromQuery] GetGamesQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GameDto>> GetGame(Guid id)
    {
        var response = await _mediator.Send(new GetGameQuery(id));
        return response != null ? Ok(response) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateGame([FromBody] CreateGameCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetGame), new { id = response }, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGame(Guid id, [FromBody] UpdateGameCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGame(Guid id)
    {
        await _mediator.Send(new DeleteGameCommand { Id = id });
        return NoContent();
    }
}
