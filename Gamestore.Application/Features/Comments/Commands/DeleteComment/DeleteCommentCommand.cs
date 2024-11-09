using MediatR;

namespace Gamestore.Application.Features.Comments.Commands.DeleteComment;

public class DeleteCommentCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
