using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public sealed class Comment : BaseEntity
{
    [ForeignKey(nameof(Game))]
    public Guid GameId { get; set; }

    public required Game Game { get; set; }

    [ForeignKey(nameof(Author))]
    public Guid AuthorId { get; set; }

    public required User Author { get; set; }

    public Guid? ParentCommentId { get; set; }

    public Comment? ParentComment { get; set; }

    public string Body { get; set; } = string.Empty;

    public ICollection<Comment> Replies { get; set; } = [];

    public bool IsBanned { get; set; }
}
