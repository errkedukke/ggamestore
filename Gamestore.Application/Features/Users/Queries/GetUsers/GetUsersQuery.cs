using MediatR;

namespace Gamestore.Application.Features.Users.Queries.GetUsers;

public record GetUsersQuery : IRequest<List<UserDto>>;
