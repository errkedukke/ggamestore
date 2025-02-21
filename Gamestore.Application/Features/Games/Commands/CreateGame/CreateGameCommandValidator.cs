using FluentValidation;

namespace Gamestore.Application.Features.Games.Commands.CreateGame;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.");

        RuleFor(x => x.GenreId)
            .NotEmpty().WithMessage("GenreId is required.");

        RuleFor(x => x.PublisherId)
            .NotEmpty().WithMessage("PublisherId is required.");

        RuleFor(x => x.Platform)
            .IsInEnum().WithMessage("Invalid platform value.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price must be a positive value.");

        RuleFor(x => x.UnitInStock)
            .GreaterThanOrEqualTo(0).WithMessage("Unit in stock must be a positive value.");

        RuleFor(x => x.ReleaseDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Release date cannot be in the future.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}
