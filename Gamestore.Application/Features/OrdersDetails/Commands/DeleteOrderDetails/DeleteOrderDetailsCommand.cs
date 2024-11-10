using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Commands.DeleteOrderDetails;

public class DeleteOrderDetailsCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
