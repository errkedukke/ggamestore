using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGames;

// Record since the result is imutable, there for faster.
public record GetGamesQuery : IRequest<List<GameDto>>;
