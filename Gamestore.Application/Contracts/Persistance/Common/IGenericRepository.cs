using Gamestore.Domain.Common;

namespace Gamestore.Application.Contracts.Persistance.Common;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken = default);

    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task CreateAsync(T entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
