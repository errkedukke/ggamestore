using Gamestore.Application.Contracts.Persistance.Common;
using Gamestore.Domain.Common;
using Gamestore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Persistence.Repositories;

public class GenericRepository<T>(GamestoreDbContext dbContext) : IGenericRepository<T> where T : BaseEntity
{
    public async Task CreateAsync(T entity)
    {
        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        dbContext.Set<T>().Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var result = await dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return result!;
    }

    public async Task UpdateAsync(T entity)
    {
        dbContext.Update(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }
}
