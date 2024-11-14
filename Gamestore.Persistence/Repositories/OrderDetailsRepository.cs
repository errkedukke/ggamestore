using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Persistence.Repositories;

public class OrderDetailsRepository : GenericRepository<OrderDetails>, IOrderDetailsRepository
{
    private readonly GamestoreDbContext _dbContext;

    public OrderDetailsRepository(GamestoreDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<OrderDetails>> GetByOrderIdAsync(Guid OrderId)
    {
        var query = _dbContext.OrderDetails.Where(x => x.Id == OrderId);
        return await query.ToListAsync();
    }
}
