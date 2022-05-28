using FluentValidation;
using System;

namespace Notes.Application.NoteTasks.Commands.CreateNoteTask
{
    public class CreateNoteTaskCommandValidator : AbstractValidator<CreateNoteTaskCommand>
    {
        public CreateNoteTaskCommandValidator()
        {
            RuleFor(createNoteTaskCommand => createNoteTaskCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createNoteTaskCommand => createNoteTaskCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createNoteTaskCommand => createNoteTaskCommand.Seconds).LessThan(2147483647);
            RuleFor(createNoteTaskCommand => createNoteTaskCommand.DateTime).Must(DateTimeIsValid).WithMessage("Date has to be in the future");
            RuleFor(createNoteTaskCommand => createNoteTaskCommand.ProgressConditionId).IsInEnum();
            RuleFor(createNoteTaskCommand => createNoteTaskCommand.MatrixId).IsInEnum();
        }
        private bool DateTimeIsValid(DateTime? dateTime)
        {
            if (dateTime < DateTime.UtcNow) return false;
            return true;
        }
    }
}
