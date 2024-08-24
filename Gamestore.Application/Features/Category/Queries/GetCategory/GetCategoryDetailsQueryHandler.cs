using MediatR;

namespace Gamestore.Application.Features.Category.Queries.GetCategory;

public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
{
    public Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
