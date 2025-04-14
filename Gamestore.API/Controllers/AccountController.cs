using Gamestore.Application.Features.Users.Commands.CreateUser;
using Gamestore.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IMediator _mediator;

    public AccountController(ILogger<AccountController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> RegisterUser(CreateUserCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateUserCommand), new { id = response }, null);
    }


}
