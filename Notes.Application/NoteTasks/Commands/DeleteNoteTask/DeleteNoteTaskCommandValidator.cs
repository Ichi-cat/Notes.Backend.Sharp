using FluentValidation;
using System;

namespace Notes.Application.NoteTasks.Commands.DeleteNoteTask
{
    public class DeleteNoteTaskCommandValidator : AbstractValidator<DeleteNoteTaskCommand>
    {
        public DeleteNoteTaskCommandValidator()
        {
            RuleFor(deleteNoteTaskCommand => deleteNoteTaskCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteNoteTaskCommand => deleteNoteTaskCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
