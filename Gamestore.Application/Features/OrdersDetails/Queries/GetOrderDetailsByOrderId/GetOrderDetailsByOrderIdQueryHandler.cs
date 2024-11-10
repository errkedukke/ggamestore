using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Queries.GetOrderDetailsByOrderId;

public class GetOrderDetailsByOrderIdQueryHandler : IRequestHandler<GetOrderDetailsByOrderIdQuery, OrderDetailsDto>
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly IMapper _mapper;

    public GetOrderDetailsByOrderIdQueryHandler(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _mapper = mapper;
    }

    public async Task<OrderDetailsDto> Handle(GetOrderDetailsByOrderIdQuery request, CancellationToken cancellationToken)
    {
        var orderDetails = await _orderDetailsRepository.GetByOrderIdAsync(request.OrderId);
        var result = _mapper.Map<OrderDetailsDto>(orderDetails);

        return result;
    }
}
