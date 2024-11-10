using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Queries.GetOrdersDetails;

public record GetOrdersDetailsQuery : IRequest<List<OrderDetailsDto>>;
