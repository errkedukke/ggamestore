using Gamestore.Application.Contracts.Email;
using Gamestore.Domain.Model;
using Gamestore.Infrastructure.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gamestore.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailOptions>(configuration.GetSection("EmailOptions"));

        // Register the email sender service
        services.AddTransient<IEmailSender, EmailSender>();


        return services;
    }
}
