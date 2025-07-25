﻿using MediatR;

namespace Gamestore.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
