using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Exceptions;
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

        if (gameToDelete == null)
        {
            throw new NotFoundException(nameof(gameToDelete), request.Id);
        }

        await _gameRepository.DeleteAsync(gameToDelete);

        return Unit.Value;
    }
}