using AutoMapper;
using Gamestore.Application.Contracts.Logging;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using MediatR;

namespace Gamestore.Application.Features.Games.Commands.UpdateGame;

public class UpdateGameCommandHandler : CommandBase<UpdateGameCommand, Unit>, IRequestHandler<UpdateGameCommand, Unit>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public UpdateGameCommandHandler(IGameRepository gameRepository, IMapper mapper, IAppLogger<UpdateGameCommand> appLogger)
        : base(appLogger)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateGameCommandValidator();
        await ValidateAsync(validator, request, cancellationToken);

        var gameToUpdate = _mapper.Map<Domain.Game>(request);
        await _gameRepository.UpdateAsync(gameToUpdate);

        return Unit.Value;
    }
}