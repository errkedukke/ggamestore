﻿using MediatR;

namespace Gamestore.Application.Features.Comments.Queries.GetComment;

public record GetCommentQuery(Guid Id) : IRequest<CommentDto>;
