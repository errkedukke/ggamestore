using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public sealed class Order : BaseEntity
{
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public required User User { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public OrderStatus OrderStatus { get; set; } = OrderStatus.Open;

    public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    public decimal Sum => OrderDetails.Sum(detail => (detail.UnitPrice - detail.Discount) * detail.Quantity);
}
