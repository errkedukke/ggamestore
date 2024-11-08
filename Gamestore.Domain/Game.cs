namespace Gamestore.Domain;

using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;

public class Game : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Category? Category { get; set; }

    public Genre? Genre { get; set; }

    public Platform Platform { get; set; }

    public Publisher? Publisher { get; set; }

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime ReleaseDate { get; set; }

    public int Views { get; set; }

    public string ImageKey { get; set; } = string.Empty;
}