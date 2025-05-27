using Gamestore.Application.Models.Identity;

namespace Gamestore.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();

    Task<User> GetUser();
}