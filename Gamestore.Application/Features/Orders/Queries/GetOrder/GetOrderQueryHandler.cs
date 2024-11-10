using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Orders.Queries.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);
        var result = _mapper.Map<OrderDto>(order);

        return result;
    }
}

