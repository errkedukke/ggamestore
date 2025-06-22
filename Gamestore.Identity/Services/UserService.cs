using Gamestore.Application.Contracts.Identity;
using Gamestore.Application.Models.Identity;
using Gamestore.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Gamestore.Identity.Services;

public class UserService(UserManager<ApplicationUser> _userManager) : IUserService
{
    public async Task<User> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return new User
        {
            Id = Guid.Parse(user!.Id),
            Email = user.Email!,
            FirstName = user.Firstname,
            LastName = user.Lastname,
        };
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userManager.GetUsersInRoleAsync("User");

        return users.Select(x => new User
        {
            Id = Guid.Parse(x!.Id),
            Email = x.Email!,
            FirstName = x.Firstname,
            LastName = x.Lastname,
        }).ToList();
    }
}
