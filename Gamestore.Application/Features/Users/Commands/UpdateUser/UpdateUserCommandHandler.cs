using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = _mapper.Map<User>(request);
        await _userRepository.UpdateAsync(userToUpdate);

        return Unit.Value;
    }
}
