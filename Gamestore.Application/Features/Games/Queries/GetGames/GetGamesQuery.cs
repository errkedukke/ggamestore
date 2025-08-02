using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGames;

public record GetGamesQuery(Guid? CategoryId, Guid? GenreId) : IRequest<List<GameDto>>;
