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
        var games = (await _gameRepository.GetAsync(cancellationToken)).AsEnumerable();

        if (request.CategoryId.HasValue)
            games = [.. games.Where(g => g.CategoryId == request.CategoryId.Value)];

        if (request.GenreId.HasValue)
            games = [.. games.Where(g => g.GenreId == request.GenreId.Value)];

        var result = _mapper.Map<List<GameDto>>(games);

        return result;
    }
}
