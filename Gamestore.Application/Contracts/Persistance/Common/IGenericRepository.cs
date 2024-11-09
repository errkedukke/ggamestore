using Gamestore.Domain.Common;

namespace Gamestore.Application.Contracts.Persistance.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();

    Task<T> GetByIdAsync(Guid id);

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<T> DeleteAsync(T id);
}
