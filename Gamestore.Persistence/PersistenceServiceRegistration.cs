using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Contracts.Persistance.Common;
using Gamestore.Persistence.DatabaseContext;
using Gamestore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gamestore.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GamestoreDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("GamestoreConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
