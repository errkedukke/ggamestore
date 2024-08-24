using MediatR;

namespace Gamestore.Application.Features.Category.Queries.GetCategories;

public record GetCategoriesQuery : IRequest<List<CategoryDto>>;
