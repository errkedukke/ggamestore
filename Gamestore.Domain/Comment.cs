using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public class Comment : BaseEntity
{
    [ForeignKey(nameof(GameId))]
    public Game? Game { get; set; }

    public Guid GameId { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public User? Author { get; set; }

    public Guid? AuthorId { get; set; }

    [ForeignKey(nameof(ParentCommentId))]
    public Guid? ParentCommentId { get; set; }

    public string Body { get; set; } = string.Empty;

    public ICollection<Comment> Replies { get; set; } = new List<Comment>();

    public bool IsBanned { get; set; }
}
