using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNotePatch
{
    public class UpdateNotePatchCommandHandler : IRequestHandler<UpdateNotePatchCommand>
    {
        private readonly INotesDbContext _context;

        public UpdateNotePatchCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateNotePatchCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (note == null || note.UserId != request.UserId)
                throw new NotFoundException(nameof(Note), request.Id);
            request.Model.ApplyTo(note);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
