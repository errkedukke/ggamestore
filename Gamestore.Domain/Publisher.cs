using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations;

public class Publisher : BaseEntity
{
    [Required]
    public string? CompanyName { get; set; }

    [Required]
    public string? HomePage { get; set; }

    public string? Description { get; set; }
}
