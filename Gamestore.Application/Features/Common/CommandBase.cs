using FluentValidation;
using Gamestore.Application.Contracts.Logging;
using Gamestore.Application.Exceptions;
using MediatR;

namespace Gamestore.Application.Features.Common;

public abstract class CommandBase<TRequest, TResponse> where TRequest
    : IRequest<TResponse>
{
    private readonly IAppLogger<TRequest> _appLogger;

    protected CommandBase(IAppLogger<TRequest> appLogger)
    {
        _appLogger = appLogger;
    }

    protected async Task ValidateAsync(AbstractValidator<TRequest> validator, TRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            var errorMessage = $"Invalid request occurred for operation '{typeof(TRequest).Name}'.";

            _appLogger.LogError(errorMessage, request);
            throw new BadRequestException(errorMessage, validationResult);
        }
    }
}
