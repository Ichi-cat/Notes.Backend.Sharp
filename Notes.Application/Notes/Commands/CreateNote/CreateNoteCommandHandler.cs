using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _context;

        public CreateNoteCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Text = request.Text,
                Category = request.Category
            };
            var result = await _context.Notes.AddAsync(note);
            var res = await _context.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}
