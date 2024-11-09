using MediatR;

namespace Gamestore.Application.Features.Comments.Commands.UpdateComment;

public class UpdateCommentCommand : IRequest<Unit>
{
    public string Body { get; set; } = string.Empty;
}
