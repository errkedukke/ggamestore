using Gamestore.Domain.Common;

namespace Gamestore.Domain;

public class OrderDetails : BaseEntity
{
    public Order? Order { get; set; }

    public Game? Game { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal Discount { get; set; }
}
