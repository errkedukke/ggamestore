using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public class Order : BaseEntity
{
    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }

    public User? Customer { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    public decimal Sum => OrderDetails.Sum(detail => (detail.UnitPrice - detail.Discount) * detail.Quantity);
}
