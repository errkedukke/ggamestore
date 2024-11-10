using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGame;

public record GetGameQuery(Guid Id) : IRequest<GameDto>;
