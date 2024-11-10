﻿using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _categoryRepository.GetByIdAsync(request.Id);
        await _categoryRepository.DeleteAsync(categoryToDelete);

        return Unit.Value;
    }
}