using FluentValidation;
using System;

namespace Notes.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListCommandValidator : AbstractValidator<GetCategoryListCommand>
    {
        public GetCategoryListCommandValidator()
        {
            RuleFor(getCategoryListCommand => getCategoryListCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
