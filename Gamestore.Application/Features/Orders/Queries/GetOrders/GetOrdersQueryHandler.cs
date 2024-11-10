using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrdersDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<OrdersDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAsync();
        var result = _mapper.Map<List<OrdersDto>>(orders);

        return result;
    }
}
