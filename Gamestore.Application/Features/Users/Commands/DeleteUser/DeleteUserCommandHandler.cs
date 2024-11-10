using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Exceptions;
using MediatR;

namespace Gamestore.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = await _userRepository.GetByIdAsync(request.Id);

        if (userToDelete == null)
        {
            throw new NotFoundException(nameof(userToDelete), request.Id);
        }

        await _userRepository.DeleteAsync(userToDelete);

        return Unit.Value;
    }
}
