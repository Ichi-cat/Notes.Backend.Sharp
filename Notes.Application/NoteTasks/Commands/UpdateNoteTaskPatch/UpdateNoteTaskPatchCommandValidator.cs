using FluentValidation;
using System;

namespace Notes.Application.NoteTasks.Commands.UpdateNoteTaskPatch
{
    public class UpdateNoteTaskPatchCommandValidator : AbstractValidator<UpdateNoteTaskPatchCommand>
    {
        public UpdateNoteTaskPatchCommandValidator()
        {
            RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteTaskCommand => updateNoteTaskCommand.UserId).NotEqual(Guid.Empty);
        }
        private bool DateTimeIsValid(DateTime? dateTime)
        {
            if (dateTime < DateTime.UtcNow) return false;
            return true;
        }
    }
}
