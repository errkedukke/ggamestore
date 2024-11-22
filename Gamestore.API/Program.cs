using Gamestore.Application;
using Gamestore.Infrastructure;
using Gamestore.Persistence;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
