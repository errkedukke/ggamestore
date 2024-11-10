using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public class Order : BaseEntity
{
    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }

    public required User Customer { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public OrderStatus OrderStatus { get; set; } = OrderStatus.Open;

    public ICollection<OrderDetails> OrderDetails { get; set; } = [];

    public decimal Sum => OrderDetails.Sum(detail => (detail.UnitPrice - detail.Discount) * detail.Quantity);
}
