using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGame;

public record GetGameQuery(Guid id) : IRequest<GameDto>;
