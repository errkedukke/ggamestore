using MediatR;

namespace Gamestore.Application.Features.Orders.Queries.GetOrders;

public record GetOrdersQuery : IRequest<List<OrdersDto>>;
