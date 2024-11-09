using Gamestore.Domain;

namespace Gamestore.Application.Features.Comments.Queries
{
    public class CommentDto
    {
        public Guid GameId { get; set; }

        public Guid? AuthorId { get; set; }

        public Guid? ParentCommentId { get; set; }

        public string Body { get; set; } = string.Empty;

        public ICollection<Comment> Replies { get; set; } = new List<Comment>();
    }
}
