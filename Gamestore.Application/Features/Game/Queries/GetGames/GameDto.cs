namespace Gamestore.Application.Features.Game.Queries.GetGames;

public class GameDto
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string ImageKey { get; set; } = string.Empty;
}
