using Gamestore.Application;
using Gamestore.Identity;
using Gamestore.Infrastructure;
using Gamestore.Persistence;

namespace Gamestore.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;

        builder.Services.AddOpenApiDocument(config =>
        {
            config.PostProcess = document =>
            {
                document.Info.Title = "GameStore API";
                document.Info.Version = "v1";
            };
        });

        builder.Services.AddOpenApi();
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddIdentityServices(builder.Configuration);
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("all", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi();
        }

        app.UseCors("all");
        //app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
