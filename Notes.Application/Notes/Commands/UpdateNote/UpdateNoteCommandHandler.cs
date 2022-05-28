using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _context;

        public UpdateNoteCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (note == null || note.UserId != request.UserId)
                throw new NotFoundException(nameof(Note), request.Id);
            note.Name = request.Name;
            note.Text = request.Text;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
