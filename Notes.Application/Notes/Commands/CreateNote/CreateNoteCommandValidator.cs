using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
            RuleFor(c => c.UserId).NotEqual(Guid.Empty);
        }
    }
}
