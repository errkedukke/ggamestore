using System.ComponentModel.DataAnnotations;

public class Publisher
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string? CompanyName { get; set; }

    [Required]
    public string? HomePage { get; set; }

    public string? Description { get; set; }
}
