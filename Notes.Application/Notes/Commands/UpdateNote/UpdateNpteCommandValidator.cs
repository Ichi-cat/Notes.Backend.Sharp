using FluentValidation;
using System;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNpteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNpteCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);
            //RuleFor(updateNoteCommand => updateNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
