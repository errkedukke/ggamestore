using System.ComponentModel.DataAnnotations;

public class Platform
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string? Type { get; set; }
}
