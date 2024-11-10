using MediatR;

namespace Gamestore.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid CustomerId { get; set; }
}