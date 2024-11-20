using AutoMapper;
using Gamestore.Application.Contracts.Logging;
using Gamestore.Application.Contracts.Persistance;
using Gamestore.Application.Features.Common;
using Gamestore.Domain;
using MediatR;

namespace Gamestore.Application.Features.Comments.Commands.CreateComment;

public class CreateCommentCommandHandler : CommandBase<CreateCommentCommand, Guid>, IRequestHandler<CreateCommentCommand, Guid>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, IAppLogger<CreateCommentCommand> logger)
        : base(logger)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCommentCommandValidator();
        await ValidateAsync(validator, request, cancellationToken);

        var commentToCreate = _mapper.Map<Comment>(request);
        await _commentRepository.CreateAsync(commentToCreate);

        return commentToCreate.Id;
    }
}
