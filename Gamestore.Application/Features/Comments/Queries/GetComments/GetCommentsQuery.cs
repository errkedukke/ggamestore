using MediatR;

namespace Gamestore.Application.Features.Comments.Queries.GetComments;

public record GetCommentsQuery : IRequest<List<CommentDto>>;
