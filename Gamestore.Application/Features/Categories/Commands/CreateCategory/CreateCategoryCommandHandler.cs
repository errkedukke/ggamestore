using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : CommandBase<CreateCategoryCommand, Guid>, IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryCommandValidator(_categoryRepository);
        await ValidateAsync(validator, request, cancellationToken);

        var categoryToCreate = _mapper.Map<Category>(request);
        await _categoryRepository.CreateAsync(categoryToCreate);

        return categoryToCreate.Id;
    }
}