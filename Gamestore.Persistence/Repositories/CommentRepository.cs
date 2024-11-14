using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(GamestoreDbContext dbContext) : base(dbContext)
    {
    }
}
