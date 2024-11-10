using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var oredrToUpdate = _mapper.Map<Order>(request);
        await _orderRepository.UpdateAsync(oredrToUpdate);

        return Unit.Value;
    }
}
