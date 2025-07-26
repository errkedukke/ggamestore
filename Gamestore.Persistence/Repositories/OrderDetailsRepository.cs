using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Persistence.Repositories;

public class OrderDetailsRepository(GamestoreDbContext dbContext)
    : GenericRepository<OrderDetails>(dbContext), IOrderDetailsRepository
{
    public async Task<IReadOnlyList<OrderDetails>> GetByOrderIdAsync(Guid OrderId)
    {
        var query = dbContext.OrderDetails.Where(x => x.Id == OrderId);
        return await query.AsNoTracking().ToListAsync();
    }
}
