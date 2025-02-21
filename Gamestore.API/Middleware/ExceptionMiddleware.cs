using Gamestore.API.Models;
using Gamestore.Application.Exceptions;
using System.Net;

namespace Gamestore.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var problem = new CustomProblemDetails();

        switch (ex)
        {
            case BadRequestException badRequest:
                statusCode = HttpStatusCode.BadRequest;
                problem.Title = badRequest.Message;
                problem.Status = (int)statusCode;
                problem.Detail = badRequest.InnerException?.Message;
                problem.Type = nameof(BadRequestException);
                problem.Errors = badRequest.ValidationErrors;
                break;
            case NotFoundException notFound:
                statusCode = HttpStatusCode.NotFound;
                problem.Title = notFound.Message;
                problem.Status = (int)statusCode;
                problem.Detail = notFound.InnerException?.Message;
                problem.Type = nameof(BadRequestException);
                break;
            default:
                statusCode = HttpStatusCode.NotFound;
                problem.Title = ex.Message;
                problem.Status = (int)statusCode;
                problem.Detail = ex.StackTrace;
                problem.Type = nameof(BadRequestException);
                break;
        }

        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsJsonAsync(problem);
    }
}
