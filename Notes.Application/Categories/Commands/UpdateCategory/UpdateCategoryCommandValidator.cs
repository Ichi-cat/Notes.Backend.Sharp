using FluentValidation;
using System;

namespace Notes.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(updateCategoryCommand => updateCategoryCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateCategoryCommand => updateCategoryCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateCategoryCommand => updateCategoryCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
