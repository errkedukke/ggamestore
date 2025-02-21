using AutoMapper;
using Gamestore.Application.Contracts.Logging;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : CommandBase<CreateCategoryCommand, Guid>, IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CreateCategoryCommandValidator _validator;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IAppLogger<CreateCategoryCommand> logger)
        : base(logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _validator = new CreateCategoryCommandValidator(_categoryRepository);
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await ValidateAsync(_validator, request, cancellationToken);

        var categoryToCreate = _mapper.Map<Category>(request);
        await _categoryRepository.CreateAsync(categoryToCreate);

        return categoryToCreate.Id;
    }
}