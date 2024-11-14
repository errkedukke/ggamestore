using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class GameRepository : GenericRepository<Game>, IGameRepository
{
    public GameRepository(GamestoreDbContext dbContext) : base(dbContext)
    {
    }
}
