using Gamestore.Application.Features.OrdersDetails.Queries;
using Gamestore.Domain.Enums;

namespace Gamestore.Application.Features.Orders.Queries.GetOrder;

public class OrderDto
{
    public Guid CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public ICollection<OrderDetailsDto> OrderDetails { get; set; } = [];

    public decimal Sum { get; set; }
}

