using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Linq;
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
            if (request.CategoryId == null || 
                !_context.Categories.Any(x => x.Id == request.CategoryId && x.UserId == request.UserId)) request.CategoryId = null;
            var note = new Note {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Name = request.Name,
                Text = request.Text,
                CategoryId = request.CategoryId
            };
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}
