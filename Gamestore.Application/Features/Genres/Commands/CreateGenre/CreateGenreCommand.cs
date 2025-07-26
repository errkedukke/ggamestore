using MediatR;

namespace Gamestore.Application.Features.Genres.Commands.CreateGenre;

public class CreateGenreCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
}
