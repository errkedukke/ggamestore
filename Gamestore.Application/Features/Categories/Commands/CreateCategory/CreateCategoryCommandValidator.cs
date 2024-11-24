﻿using FluentValidation;
using Gamestore.Application.Contracts.Persistance;

namespace Gamestore.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Category name is required.")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");

        RuleFor(x => x)
            .MustAsync(CategoryNameUnique).WithMessage("Category with this name already exists");
    }

    private Task<bool> CategoryNameUnique(CreateCategoryCommand command, CancellationToken token)
    {
        return _categoryRepository.IsCategoryUnique(command.CategoryName);
    }
}
