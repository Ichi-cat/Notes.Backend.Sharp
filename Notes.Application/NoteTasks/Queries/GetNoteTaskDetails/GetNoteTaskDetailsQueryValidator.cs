using FluentValidation;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskDetails
{
    public class GetNoteTaskDetailsQueryValidator : AbstractValidator<GetNoteTaskDetailsQuery>
    {
        public GetNoteTaskDetailsQueryValidator()
        {
            RuleFor(getNoteTaskDetailsQuery => getNoteTaskDetailsQuery.Id).NotEqual(Guid.Empty);
            RuleFor(getNoteTaskDetailsQuery => getNoteTaskDetailsQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
