using FluentValidation;
using Gamestore.Application.Exceptions;
using MediatR;

namespace Gamestore.Application.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(x => x.Errors).Where(x => x != null).ToList();

            if (failures.Count > 0)
            {
                var errorMessage = $"Invalid request occurred for operation '{typeof(TRequest).Name}'.";
                throw new BadRequestException(errorMessage, new FluentValidation.Results.ValidationResult(failures));
            }
        }

        return await next();
    }
}
