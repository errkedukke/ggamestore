using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Exceptions;
using MediatR;
namespace Gamestore.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
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
        var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"The category with the ID: {request.Id} was not found.");

        _mapper.Map(request, categoryToUpdate);
        await _categoryRepository.UpdateAsync(categoryToUpdate, cancellationToken);

        return Unit.Value;
    }
}
