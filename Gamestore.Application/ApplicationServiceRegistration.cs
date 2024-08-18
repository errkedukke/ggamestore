using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gamestore.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var executionAssembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(executionAssembly);
        services.AddMediatR(x => x.RegisterServicesFromAssembly(executionAssembly));

        return services;
    }
}