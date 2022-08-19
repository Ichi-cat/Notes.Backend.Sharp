using FluentValidation;
using System;

namespace Notes.Application.Notes.Commands.UpdateNotePatch
{
    public class UpdateNotePatchCommandValidator : AbstractValidator<UpdateNotePatchCommand>
    {
        public UpdateNotePatchCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.UserId).NotEqual(Guid.Empty);
            //RuleFor(updateNoteCommand => updateNoteCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}
