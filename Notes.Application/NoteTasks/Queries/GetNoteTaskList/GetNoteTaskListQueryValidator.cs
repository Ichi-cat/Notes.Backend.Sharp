using FluentValidation;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskList
{
    public class GetNoteTaskListQueryValidator : AbstractValidator<GetNoteTaskListQuery>
    {
        public GetNoteTaskListQueryValidator()
        {
            RuleFor(getNoteTaskListQuery => getNoteTaskListQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
