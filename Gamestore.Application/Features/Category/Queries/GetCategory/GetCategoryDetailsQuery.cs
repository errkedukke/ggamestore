using MediatR;

namespace Gamestore.Application.Features.Category.Queries.GetCategory;

public record GetCategoryDetailsQuery(int id) : IRequest<CategoryDetailsDto>;
