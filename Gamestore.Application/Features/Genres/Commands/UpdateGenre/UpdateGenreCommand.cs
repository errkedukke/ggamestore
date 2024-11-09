using MediatR;

namespace Gamestore.Application.Features.Genres.Commands.UpdateGenre;

public class UpdateGenreCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;

    public Guid ParentId { get; set; }
}
