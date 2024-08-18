using System.ComponentModel.DataAnnotations;

namespace Gamestore.Domain.Common;

public class BaseEntity
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }

    [Required]
    public DateTime DateModified { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
}
