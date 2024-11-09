using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public class Comment : BaseEntity
{
    [ForeignKey(nameof(Game))]
    public Guid GameId { get; set; }

    public Game? Game { get; set; }

    [ForeignKey(nameof(Author))]
    public Guid? AuthorId { get; set; }

    public User? Author { get; set; }

    public Guid? ParentCommentId { get; set; }

    public Comment? ParentComment { get; set; }

    public string Body { get; set; } = string.Empty;

    public ICollection<Comment> Replies { get; set; } = new List<Comment>();

    public bool IsBanned { get; set; }
}
