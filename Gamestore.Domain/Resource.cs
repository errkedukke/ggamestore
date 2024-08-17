using Gamestore.Domain.Enums;

public class Resource
{
    public Guid Id { get; set; }

    public Guid GameId { get; set; }

    public Language Language { get; set; }

    public string Key { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}