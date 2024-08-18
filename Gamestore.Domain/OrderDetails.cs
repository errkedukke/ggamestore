using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderDetails : BaseEntity
{
    [Required]
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }

    [Required]
    [ForeignKey(nameof(Game))]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal Discount { get; set; }
}
