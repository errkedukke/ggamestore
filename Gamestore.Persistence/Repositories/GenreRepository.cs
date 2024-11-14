using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(GamestoreDbContext dbContext) : base(dbContext)
    {
    }
}
