using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class UserRepository(GamestoreDbContext dbContext)
    : GenericRepository<User>(dbContext), IUserRepository;
