using Gamestore.Domain.Enums;
using MediatR;

namespace Gamestore.Application.Features.Game.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;

        public Platform Platform { get; set; }

        public decimal Price { get; set; }

        public int UnitInStock { get; set; }

        public bool Discontinued { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
