using FluentValidation;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskListByMatrix
{
    public class GetNoteTaskListByMatrixQueryValidator : AbstractValidator<GetNoteTaskListByMatrixQuery>
    {
        public GetNoteTaskListByMatrixQueryValidator()
        {
            RuleFor(getNoteTaskListByMatrixQuery => getNoteTaskListByMatrixQuery.UserId).NotEqual(Guid.Empty);
            RuleFor(getNoteTaskListByMatrixQuery => getNoteTaskListByMatrixQuery.MatrixId).NotNull().IsInEnum();
        }
    }
}
