using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations;

public class Genre : BaseEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Parent { get; set; } = string.Empty;
}