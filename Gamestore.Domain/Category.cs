using Gamestore.Domain.Common;

public class Category : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public byte[] Picture { get; set; } = [];
}