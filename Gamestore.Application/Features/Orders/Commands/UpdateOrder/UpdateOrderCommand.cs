using Gamestore.Domain.Enums;
using MediatR;

namespace Gamestore.Application.Features.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest<Unit>
{
    public Guid CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }
}
