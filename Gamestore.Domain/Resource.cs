using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;

public class Resource : BaseEntity
{
    public Game? Game { get; set; }

    public Language Language { get; set; }

    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}