using AutoMapper;
using Gamestore.Application.Contracts.Logging;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using MediatR;

namespace Gamestore.Application.Features.Games.Commands.CreateGame;

public class CreateGameCommandHandler : CommandBase<CreateGameCommand, Guid>, IRequestHandler<CreateGameCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IGameRepository _gameRepository;

    public CreateGameCommandHandler(IMapper mapper, IGameRepository gameRepository, IAppLogger<CreateGameCommand> appLogger)
        : base(appLogger)
    {
        _mapper = mapper;
        _gameRepository = gameRepository;
    }

    public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateGameCommandValidator();
        await ValidateAsync(validator, request, cancellationToken);

        var gameToCreate = _mapper.Map<Domain.Game>(request);
        await _gameRepository.CreateAsync(gameToCreate);

        return gameToCreate.Id;
    }
}
