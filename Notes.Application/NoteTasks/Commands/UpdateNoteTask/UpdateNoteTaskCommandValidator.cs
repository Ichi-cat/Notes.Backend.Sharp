using FluentValidation;
using System;

namespace Notes.Application.NoteTasks.Commands.UpdateNoteTask
{
    public class UpdateNoteTaskPatchCommandValidator : AbstractValidator<UpdateNoteTaskCommand>
    {
        public UpdateNoteTaskPatchCommandValidator()
        {
            RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.Seconds).LessThan(2147483647);
            //RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.DateTime).Must(DateTimeIsValid).WithMessage("Date has to be in the future");
            RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.MatrixId).IsInEnum();
            RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.ProgressConditionId).IsInEnum();
        }
        private bool DateTimeIsValid(DateTime? dateTime)
        {
            if (dateTime < DateTime.UtcNow) return false;
            return true;
        }
    }
}
