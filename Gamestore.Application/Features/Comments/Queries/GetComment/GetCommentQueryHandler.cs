using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Comments.Queries.GetComment;

public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentDto>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<CommentDto> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(request.Id);
        var result = _mapper.Map<CommentDto>(comment);

        return result;
    }
}