using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain;

public class OrderDetails : BaseEntity
{
    [ForeignKey(nameof(Game))]
    public Guid GameId { get; set; }

    public required Game Game { get; set; }

    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }

    public required Order Order { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; } = 1;

    public decimal Discount { get; set; }
}
