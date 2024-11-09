using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Games.Commands.UpdateGame;

public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Unit>
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public UpdateGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var gameToUpdate = _mapper.Map<Domain.Game>(request);
        await _gameRepository.UpdateAsync(gameToUpdate);

        return Unit.Value;
    }
}