using FluentValidation;
using Gamestore.Application.Exceptions;

namespace Gamestore.Application.Features.Common
{
    public abstract class CommandBase<TRequest, TResponse> where TRequest : class
    {
        protected async Task ValidateAsync(AbstractValidator<TRequest> validator, TRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Request", validationResult);
            }
        }
    }
}
