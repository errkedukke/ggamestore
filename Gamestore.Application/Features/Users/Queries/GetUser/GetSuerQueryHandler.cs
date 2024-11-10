using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Users.Queries.GetUser;

public class GetSuerQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetSuerQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        var result = _mapper.Map<UserDto>(user);

        return result;
    }
}
