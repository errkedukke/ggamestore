using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGame;

public record GetGameDetailsQuery(Guid id) : IRequest<GameDto>;
