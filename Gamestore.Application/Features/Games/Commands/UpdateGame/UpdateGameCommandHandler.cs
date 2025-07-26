using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Exceptions;
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
        var gameToUpdate = await _gameRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"The game with the ID: {request.Id} was not found.");

        _mapper.Map(request, gameToUpdate);
        await _gameRepository.UpdateAsync(gameToUpdate, cancellationToken);

        return Unit.Value;
    }
}
