using MediatR;

namespace Gamestore.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Guid>
    {
        public Task<Guid> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
