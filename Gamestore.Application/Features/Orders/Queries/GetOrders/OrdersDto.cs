using Gamestore.Domain.Enums;

namespace Gamestore.Application.Features.Orders.Queries.GetOrders;

public class OrdersDto
{
    public Guid CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public decimal Sum { get; set; }
}
