using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class CommentRepository(GamestoreDbContext dbContext)
    : GenericRepository<Comment>(dbContext), ICommentRepository;
