using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Game : BaseEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Key { get; set; } = string.Empty;

    [ForeignKey(nameof(Genre))]
    public int? GenreId { get; set; }

    [Required]
    [ForeignKey(nameof(Platform))]
    public int PlatformId { get; set; }

    [ForeignKey(nameof(Publisher))]
    public int? PublisherId { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int UnitInStock { get; set; }

    [Required]
    public bool Discontinued { get; set; }

    public string? Description { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public int Views { get; set; }

    public string? ImageKey { get; set; }
}