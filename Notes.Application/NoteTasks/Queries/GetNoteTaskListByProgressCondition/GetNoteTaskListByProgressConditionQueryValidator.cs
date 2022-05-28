using FluentValidation;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskListByProgressCondition
{
    public class GetNoteTaskListByProgressConditionQueryValidator : AbstractValidator<GetNoteTaskListByProgressConditionQuery>
    {
        public GetNoteTaskListByProgressConditionQueryValidator()
        {
            RuleFor(getNoteTaskListByProgressConditionQuery => getNoteTaskListByProgressConditionQuery.UserId).NotEqual(Guid.Empty);
            RuleFor(getNoteTaskListByProgressConditionQuery => getNoteTaskListByProgressConditionQuery.ProgressConditionId).IsInEnum();
        }
    }
}
