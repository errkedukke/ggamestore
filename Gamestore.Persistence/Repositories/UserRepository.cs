using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(GamestoreDbContext dbContext) : base(dbContext)
    {
    }
}
