using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.NoteTasks.Commands.DeleteNoteTask
{
    public class DeleteNoteTaskCommandHandler : IRequestHandler<DeleteNoteTaskCommand>
    {
        private readonly INotesDbContext _context;

        public DeleteNoteTaskCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteNoteTaskCommand request, CancellationToken cancellationToken)
        {
            var noteTask = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (noteTask == null || noteTask.UserId != request.UserId)
                throw new NotFoundException(nameof(NoteTask), request.Id);
            _context.Tasks.Remove(noteTask);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
