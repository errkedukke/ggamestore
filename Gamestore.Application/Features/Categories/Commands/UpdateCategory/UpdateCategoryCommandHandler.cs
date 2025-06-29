﻿using AutoMapper;
using Gamestore.Application.Contracts.Logging;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using Gamestore.Domain;
using MediatR;
namespace Gamestore.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : CommandBase<UpdateCategoryCommand, Unit>, IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly UpdateCategoryCommandValidator _validator;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IAppLogger<UpdateCategoryCommand> logger) : base(logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _validator = new UpdateCategoryCommandValidator();
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await ValidateAsync(_validator, request, cancellationToken);

        var categoryToUpdate = _mapper.Map<Category>(request);
        await _categoryRepository.UpdateAsync(categoryToUpdate);

        return Unit.Value;
    }
}
