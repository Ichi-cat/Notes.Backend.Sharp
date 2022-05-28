using FluentValidation;
using System;

namespace Notes.Application.Notes.Queries.GetNoteListByCategory
{
    public class GetNoteListByCategoryQueryValidator : AbstractValidator<GetNoteListByCategoryQuery>
    {
        public GetNoteListByCategoryQueryValidator()
        {
            RuleFor(getNoteListByCategoryQuery => getNoteListByCategoryQuery.UserId).NotEqual(Guid.Empty);
            RuleFor(getNoteListByCategoryQuery => getNoteListByCategoryQuery.CategoryId).NotEqual(Guid.Empty);
        }
    }
}
