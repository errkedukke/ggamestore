using Gamestore.Domain.Common;
using Gamestore.Domain.Enums;

public class Order : BaseEntity
{
    public Customer? Customer { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public decimal Sum { get; set; }
}
