using Gamestore.Application.Contracts.Persistance.Common;
using Gamestore.Domain.Common;
using Gamestore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Persistence.Repositories;

public class GenericRepository<T>(GamestoreDbContext dbContext)
    : IGenericRepository<T> where T : BaseEntity
{
    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    // Would be a huge plus if there would be a configurable option for this method, would you want
    // a soft delete or hard delete on your entities
    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        dbContext.Entry(entity).Property(e => e.IsDeleted).IsModified = true;

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await dbContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return result!;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        dbContext.Update(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
