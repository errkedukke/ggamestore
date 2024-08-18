using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order : BaseEntity
{
    [Required]
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public OrderStatus OrderStatus { get; set; }

}
