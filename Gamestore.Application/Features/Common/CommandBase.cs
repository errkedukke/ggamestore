using FluentValidation;
using Gamestore.Application.Exceptions;
using MediatR;

namespace Gamestore.Application.Features.Common
{
    public abstract class CommandBase<TRequest, TResponse> where TRequest : IRequest<TResponse>
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
