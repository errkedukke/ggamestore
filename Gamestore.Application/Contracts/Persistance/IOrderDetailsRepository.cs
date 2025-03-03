﻿using Gamestore.Application.Contracts.Persistance.Common;
using Gamestore.Domain;

namespace Gamestore.Application.Contracts.Persistance;

public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
{
    Task<IReadOnlyList<OrderDetails>> GetByOrderIdAsync(Guid OrderId);
}
