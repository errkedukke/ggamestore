using Gamestore.Domain.Common;

namespace Gamestore.Application.Contracts.Persistance.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();

    Task<T> GetByIdAsync(Guid id);

    Task CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
