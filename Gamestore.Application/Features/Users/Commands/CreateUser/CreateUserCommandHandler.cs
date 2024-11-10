using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userToCreate = _mapper.Map<User>(request);
        await _userRepository.CreateAsync(userToCreate);

        return userToCreate.Id;
    }
}
