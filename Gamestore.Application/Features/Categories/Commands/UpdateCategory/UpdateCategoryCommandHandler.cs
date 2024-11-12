using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using Gamestore.Domain;
using MediatR;
namespace Gamestore.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : CommandBase<UpdateCategoryCommand, Unit>, IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryCommandValidator();
        await ValidateAsync(validator, request, cancellationToken);

        var categoryToUpdate = _mapper.Map<Category>(request);
        await _categoryRepository.UpdateAsync(categoryToUpdate);

        return Unit.Value;
    }
}
