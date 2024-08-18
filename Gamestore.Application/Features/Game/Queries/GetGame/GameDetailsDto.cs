namespace Gamestore.Application.Features.Game.Queries.GetGame;

public class GameDetailsDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int Views { get; set; }

    public string ImageKey { get; set; } = string.Empty;
}
