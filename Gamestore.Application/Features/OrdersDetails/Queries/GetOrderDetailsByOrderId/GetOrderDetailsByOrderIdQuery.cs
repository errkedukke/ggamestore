using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Queries.GetOrderDetailsByOrderId;

public record GetOrderDetailsByOrderIdQuery(Guid OrderId) : IRequest<OrderDetailsDto>;
