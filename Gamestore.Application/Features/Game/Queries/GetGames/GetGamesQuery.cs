using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGames;

public record GetGamesQuery : IRequest<List<GameDto>>;
