using Gamestore.Application.Contracts.Persistance.Common;
using Gamestore.Domain.Common;
using Gamestore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly GamestoreDbContext _dbContext;

    public GenericRepository(GamestoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Update(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
