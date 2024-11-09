using MediatR;

namespace Gamestore.Application.Features.Genres.Commands.DeleteGenre;

public class DeleteGenreCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
