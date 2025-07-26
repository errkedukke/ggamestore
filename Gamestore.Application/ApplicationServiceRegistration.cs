using FluentValidation;
using Gamestore.Application.Common.Behaviours;
using MediatR;
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
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddValidatorsFromAssembly(executionAssembly);

        return services;
    }
}