using System.ComponentModel.DataAnnotations;

public class Genre
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Parent { get; set; } = string.Empty;
}