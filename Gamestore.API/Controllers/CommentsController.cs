using Gamestore.Application.Features.Comments.Commands.CreateComment;
using Gamestore.Application.Features.Comments.Commands.DeleteComment;
using Gamestore.Application.Features.Comments.Commands.UpdateComment;
using Gamestore.Application.Features.Comments.Queries;
using Gamestore.Application.Features.Comments.Queries.GetComment;
using Gamestore.Application.Features.Comments.Queries.GetComments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ILogger<CommentsController> _logger;
    private readonly IMediator _mediator;

    public CommentsController(ILogger<CommentsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CommentDto>>> GetComments()
    {
        var response = await _mediator.Send(new GetCommentsQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CommentDto>> GetComment(Guid id)
    {
        var response = await _mediator.Send(new GetCommentQuery(id));
        return response != null ? Ok(response) : NotFound();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateComment(CreateCommentCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetComment), new { id = response }, null);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateComment(Guid id, UpdateCommentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        await _mediator.Send(new DeleteCommentCommand { Id = id });
        return NoContent();
    }
}
