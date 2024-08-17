using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Game
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Key { get; set; } = string.Empty;

    [ForeignKey(nameof(Genre))]
    public Guid? GenreId { get; set; }

    [Required]
    [ForeignKey(nameof(Platform))]
    public Guid PlatformId { get; set; }

    [ForeignKey(nameof(Publisher))]
    public Guid? PublisherId { get; set; }

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

    public bool IsDeleted { get; set; }

    public string? ImageKey { get; set; }
}