using FluentValidation;
using System;

namespace Notes.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(deleteCategoryCommand => deleteCategoryCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteCategoryCommand => deleteCategoryCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
