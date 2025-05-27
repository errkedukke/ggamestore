namespace Gamestore.Application.Models.Identity;

public class AuthResponse
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Toke { get; set; }
}

