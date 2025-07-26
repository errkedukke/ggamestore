using Gamestore.Domain.Common;

namespace Gamestore.Domain;

public sealed class Genre : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}