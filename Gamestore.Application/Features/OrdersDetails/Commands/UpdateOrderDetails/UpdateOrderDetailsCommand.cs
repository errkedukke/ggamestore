using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Commands.UpdateOrderDetails;

public class UpdateOrderDetailsCommand : IRequest<Unit>
{
    public Guid GameId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; } = 1;

    public decimal Discount { get; set; }
}
