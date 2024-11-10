using MediatR;

namespace Gamestore.Application.Features.Categories.Queries.GetCategory;

public record GetCategoryQuery(Guid Id) : IRequest<CategoryDto>;
