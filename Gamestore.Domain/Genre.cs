using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public sealed class Genre : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    [ForeignKey(nameof(Parent))]
    public Guid ParentId { get; set; }

    public Genre? Parent { get; set; }
}