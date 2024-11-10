using MediatR;

namespace Gamestore.Application.Features.Orders.Queries.GetOrder;

public record GetOrderQuery(Guid Id) : IRequest<OrderDto>;

