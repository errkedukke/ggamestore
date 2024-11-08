namespace Gamestore.Domain;

using Gamestore.Domain.Common;

public class Genre : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Genre? Parent { get; set; }
}