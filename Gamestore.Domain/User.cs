namespace Gamestore.Domain;

using Gamestore.Domain.Common;

public class User : BaseEntity
{
    public string Firstname { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;
}
