using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly GamestoreDbContext _dbContext;

    public CategoryRepository(GamestoreDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> IsCategoryUnique(string categoryName)
    {
        return !await _dbContext.Categories.AsNoTracking().AnyAsync(c => c.CategoryName == categoryName);
    }
}
