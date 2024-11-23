using FluentValidation.Results;

namespace Gamestore.Application.Exceptions;

public class BadRequestException : Exception
{
    public List<string> ValidationErrors { get; set; }

    public BadRequestException(string message)
        : base(message)
    {
        ValidationErrors = new List<string>();
    }

    public BadRequestException(string message, ValidationResult validationResult)
        : base(message)
    {
        ValidationErrors = new List<string>();

        foreach (var error in validationResult.Errors)
        {
            ValidationErrors.Add(error.ErrorMessage);
        }
    }
}
