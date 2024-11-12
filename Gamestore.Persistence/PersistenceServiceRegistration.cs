using Gamestore.Persistence.DatabaseContext;
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

        return services;
    }
}
