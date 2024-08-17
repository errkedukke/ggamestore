using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderDetails
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }

    [Required]
    [ForeignKey(nameof(Game))]
    public Guid ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal Discount { get; set; }
}
