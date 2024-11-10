﻿using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.OrdersDetails.Queries;
using MediatR;

namespace Gamestore.Application.Features.Orders.Queries.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IOrderRepository orderRepository, IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _orderDetailsRepository = orderDetailsRepository;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);
        var result = _mapper.Map<OrderDto>(order);
        var orderDetails = await _orderDetailsRepository.GetByOrderIdAsync(order.Id);
        var orderDetailsDto = _mapper.Map<List<OrderDetailsDto>>(orderDetails);

        result.OrderDetails = orderDetailsDto;

        return result;
    }
}
