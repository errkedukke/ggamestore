using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;

namespace Gamestore.Persistence.Repositories;

public class OrderRepository(GamestoreDbContext dbContext)
    : GenericRepository<Order>(dbContext), IOrderRepository;
