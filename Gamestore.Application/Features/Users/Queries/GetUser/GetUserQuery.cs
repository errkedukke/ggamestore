using MediatR;

namespace Gamestore.Application.Features.Users.Queries.GetUser;

public record GetUserQuery(Guid Id) : IRequest<UserDto>;
