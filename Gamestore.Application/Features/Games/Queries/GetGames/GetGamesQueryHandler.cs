using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
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
        var games = await _gameRepository.GetAsync();
        var result = _mapper.Map<List<GameDto>>(games);

        return result;
    }
}
