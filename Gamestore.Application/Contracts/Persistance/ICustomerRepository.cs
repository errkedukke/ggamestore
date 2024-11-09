using Gamestore.Application.Contracts.Persistance.Common;
using Gamestore.Domain;

namespace Gamestore.Application.Contracts.Persistance;

public interface ICustomerRepository : IGenericRepository<User>
{
}
