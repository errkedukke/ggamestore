using AutoMapper;
using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGame;

public class GetGameDetailsQueryHandler : IRequestHandler<GetGameDetailsQuery, GameDetailsDto>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GetGameDetailsQueryHandler(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<GameDetailsDto> Handle(GetGameDetailsQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(request.id);
        var result = _mapper.Map<GameDetailsDto>(game);

        return result;
    }
}
