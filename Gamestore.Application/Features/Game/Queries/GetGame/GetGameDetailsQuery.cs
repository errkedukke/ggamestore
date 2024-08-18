using MediatR;

namespace Gamestore.Application.Features.Game.Queries.GetGame;

public record GetGameDetailsQuery(int id) : IRequest<GameDetailsDto>;
