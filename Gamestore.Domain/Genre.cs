using Gamestore.Domain.Common;

namespace Gamestore.Domain;

public class Genre : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Genre? Parent { get; set; }
}