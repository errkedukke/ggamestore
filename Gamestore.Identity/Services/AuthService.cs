using Gamestore.Application.Contracts.Identity;
using Gamestore.Application.Exceptions;
using Gamestore.Application.Models.Identity;
using Gamestore.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Gamestore.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new NotFoundException($"The user with email {request.Email} was not found");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded == false)
        {
            throw new BadRequestException($"User or password is incorrect.");
        }

        var token = await GenerateToken(user);
    }

    private async Task<JsonWebToken> GenerateToken(ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(CustomClaimType.Uid, user.Id),
        }
        .Union(userClaims)
        .Union(roleClaims);


    }

    public Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        throw new NotImplementedException();
    }
}
