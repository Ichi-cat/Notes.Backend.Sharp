using FluentValidation;
using System;

namespace Notes.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(createCategoryCommand => createCategoryCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createCategoryCommand => createCategoryCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
