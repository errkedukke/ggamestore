using Gamestore.Application.Contracts.Persistance;
using MediatR;

namespace Gamestore.Application.Features.Comments.Commands.DeleteComment;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var commentToDelete = await _commentRepository.GetByIdAsync(request.Id);
        await _commentRepository.DeleteAsync(commentToDelete);

        return Unit.Value;
    }
}
