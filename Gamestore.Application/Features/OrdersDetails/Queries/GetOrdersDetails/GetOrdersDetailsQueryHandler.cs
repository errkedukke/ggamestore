using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Queries.GetOrdersDetails;

public class GetOrdersDetailsQueryHandler : IRequestHandler<GetOrdersDetailsQuery, List<OrderDetailsDto>>
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly IMapper _mapper;

    public GetOrdersDetailsQueryHandler(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _mapper = mapper;
    }

    public async Task<List<OrderDetailsDto>> Handle(GetOrdersDetailsQuery request, CancellationToken cancellationToken)
    {
        var orderDetails = await _orderDetailsRepository.GetAsync();
        var result = _mapper.Map<List<OrderDetailsDto>>(orderDetails);

        return result;
    }
}
