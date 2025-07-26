using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Exceptions;
using MediatR;

namespace Gamestore.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<DeleteCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await categoryRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"The category with the ID: {request.Id} was not found.");

        await categoryRepository.DeleteAsync(categoryToDelete, cancellationToken);

        return Unit.Value;
    }
}
