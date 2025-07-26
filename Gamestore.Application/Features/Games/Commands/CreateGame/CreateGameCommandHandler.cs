using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Games.Commands.CreateGame;

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IGameRepository _gameRepository;

    public CreateGameCommandHandler(IMapper mapper, IGameRepository gameRepository)
    {
        _mapper = mapper;
        _gameRepository = gameRepository;
    }

    public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var gameToCreate = _mapper.Map<Domain.Game>(request);
        await _gameRepository.CreateAsync(gameToCreate, cancellationToken);

        return gameToCreate.Id;
    }
}

