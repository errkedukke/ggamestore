using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetAllGames;

// Record since the result is imutable, there for faster.
public record GetGamesQuery : IRequest<List<GameDto>>;
