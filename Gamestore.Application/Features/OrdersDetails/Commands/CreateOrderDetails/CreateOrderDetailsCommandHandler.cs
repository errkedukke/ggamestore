using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Commands.CreateOrderDetails;

public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand, Guid>
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly IMapper _mapper;

    public CreateOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var orderDetailsToCreate = _mapper.Map<OrderDetails>(request);
        await _orderDetailsRepository.CreateAsync(orderDetailsToCreate);

        return orderDetailsToCreate.Id;
    }
}
