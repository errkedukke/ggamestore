using MediatR;

namespace Gamestore.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
