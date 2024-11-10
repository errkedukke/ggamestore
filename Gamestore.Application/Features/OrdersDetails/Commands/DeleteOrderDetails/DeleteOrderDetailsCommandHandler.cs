﻿using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.OrdersDetails.Commands.DeleteOrderDetails;

public class DeleteOrderDetailsCommandHandler : IRequestHandler<DeleteOrderDetailsCommand, Unit>
{
    private readonly IOrderDetailsRepository _orderDetailsRepository;

    public DeleteOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
    {
        _orderDetailsRepository = orderDetailsRepository;
    }

    public async Task<Unit> Handle(DeleteOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var orderDetailsToDelete = await _orderDetailsRepository.GetByIdAsync(request.Id);
        await _orderDetailsRepository.DeleteAsync(orderDetailsToDelete);

        return Unit.Value;
    }
}