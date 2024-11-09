using MediatR;

namespace Gamestore.Application.Features.Comments.Commands.CreateComment;

public class CreateCommentCommand : IRequest<Guid>
{
    public Guid GameId { get; set; }

    public Guid AuthorId { get; set; }

    public Guid? ParentCommentId { get; set; }

    public string Body { get; set; } = string.Empty;
}
