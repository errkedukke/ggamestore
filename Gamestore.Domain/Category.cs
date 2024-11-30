using Gamestore.Domain.Common;

namespace Gamestore.Domain;

public sealed class Category : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}