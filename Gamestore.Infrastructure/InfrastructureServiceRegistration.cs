using Gamestore.Application.Contracts.Email;
using Gamestore.Application.Contracts.Logging;
using Gamestore.Domain.Model;
using Gamestore.Infrastructure.EmailService;
using Gamestore.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gamestore.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailOptions>(configuration.GetSection("EmailOptions"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));

        return services;
    }
}
