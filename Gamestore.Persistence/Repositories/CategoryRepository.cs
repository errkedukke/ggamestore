using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using Gamestore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Persistence.Repositories;

public class CategoryRepository(GamestoreDbContext dbContext)
    : GenericRepository<Category>(dbContext), ICategoryRepository
{
    public async Task<bool> IsCategoryUnique(string categoryName)
    {
        var normalized = categoryName.Trim().ToLower();
        return !await dbContext.Categories.AsNoTracking().AnyAsync(c => c.CategoryName.ToLower().Trim() == normalized);
    }
}
