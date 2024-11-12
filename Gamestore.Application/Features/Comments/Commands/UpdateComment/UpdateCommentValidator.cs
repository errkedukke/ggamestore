using FluentValidation;

namespace Gamestore.Application.Features.Comments.Commands.UpdateComment;

public class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentValidator()
    {
        RuleFor(x => x.Body)
            .NotEmpty().WithMessage("Comment body is required.")
            .MaximumLength(500).WithMessage("Comment body must not exceed 500 characters.");
    }
}