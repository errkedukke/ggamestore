using AutoMapper;
using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGames;

public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, List<GameDto>>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GetGamesQueryHandler(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<List<GameDto>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetAsync();
        var result = _mapper.Map<List<GameDto>>(game);

        return result;
    }
}
