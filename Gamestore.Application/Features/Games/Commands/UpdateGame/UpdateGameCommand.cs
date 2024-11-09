using Gamestore.Domain.Enums;
using MediatR;

namespace Gamestore.Application.Features.Games.Commands.UpdateGame;

public class UpdateGameCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }

    public Guid GenreId { get; set; }

    public Guid PublisherId { get; set; }

    public Platform Platform { get; set; }

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string Description { get; set; } = string.Empty;
}
