using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Games.Commands.DeleteGame;

public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, Unit>
{
    private readonly IGameRepository _gameRepository;

    public DeleteGameCommandHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var gameToDelete = await _gameRepository.GetByIdAsync(request.Id);
        await _gameRepository.DeleteAsync(gameToDelete);

        return Unit.Value;
    }
}