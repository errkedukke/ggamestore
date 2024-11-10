using MediatR;

namespace Gamestore.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<Unit>
{
    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;
}
