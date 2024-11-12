using AutoMapper;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Comments.Commands.UpdateComment;

public class UpdateCommentCommandHandler : CommandBase<UpdateCommentCommand, Unit>, IRequestHandler<UpdateCommentCommand, Unit>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCommentValidator();
        await ValidateAsync(validator, request, cancellationToken);

        var commentToUpdate = _mapper.Map<Comment>(request);
        await _commentRepository.UpdateAsync(commentToUpdate);

        return Unit.Value;
    }
}