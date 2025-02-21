using Gamestore.Domain.Common;

namespace Gamestore.Domain;

public sealed class User : BaseEntity
{
    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;
}
