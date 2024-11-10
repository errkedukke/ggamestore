using MediatR;

namespace Gamestore.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
