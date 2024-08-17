using System.ComponentModel.DataAnnotations;

public class Category
{
    [Required]
    public Guid Id { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public byte[] Picture { get; set; } = [];
}