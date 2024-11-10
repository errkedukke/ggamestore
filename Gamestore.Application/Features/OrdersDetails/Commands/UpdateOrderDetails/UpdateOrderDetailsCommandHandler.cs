using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Commands.UpdateOrderDetails;

public class UpdateOrderDetailsCommandHandler : IRequestHandler<UpdateOrderDetailsCommand, Unit>
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;
    private readonly IMapper _mapper;

    public UpdateOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
    {
        _orderDetailsRepository = orderDetailsRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var orderDetailsToUpdate = _mapper.Map<OrderDetails>(request);
        await _orderDetailsRepository.UpdateAsync(orderDetailsToUpdate);

        return Unit.Value;
    }
}
