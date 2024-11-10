using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Queries.GetOrderDetails;

public record GetOrderDetailsQuery(Guid Id) : IRequest<OrderDetailsDto>;
