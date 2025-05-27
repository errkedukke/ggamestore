using Gamestore.Application.Models.Identity;

namespace Gamestore.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);

    Task<RegistrationResponse> Register(RegistrationRequest request);
}
