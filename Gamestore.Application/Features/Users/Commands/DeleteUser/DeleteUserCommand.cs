using MediatR;

namespace Gamestore.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
