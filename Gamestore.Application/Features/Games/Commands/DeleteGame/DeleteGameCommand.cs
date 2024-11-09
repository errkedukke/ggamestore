using MediatR;

namespace Gamestore.Application.Features.Games.Commands.DeleteGame;

public class DeleteGameCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
