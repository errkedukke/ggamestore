namespace Gamestore.Application.Features.Game.Queries;

public class GameDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string ImageKey { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;
}
