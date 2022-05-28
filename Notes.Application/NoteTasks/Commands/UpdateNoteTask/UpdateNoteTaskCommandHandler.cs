using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.NoteTasks.Commands.UpdateNoteTask
{
    public class UpdateNoteTaskCommandHandler : IRequestHandler<UpdateNoteTaskCommand>
    {
        private readonly INotesDbContext _context;

        public UpdateNoteTaskCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateNoteTaskCommand request, CancellationToken cancellationToken)
        {
            var noteTask = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (noteTask == null || noteTask.UserId != request.UserId)
                throw new NotFoundException(nameof(NoteTask), request.Id);
            noteTask.Name = request.Name;
            noteTask.Text = request.Text;
            noteTask.Seconds = request.Seconds;
            noteTask.Date = request.DateTime;
            noteTask.MatrixId = request.MatrixId;
            noteTask.ProgressConditionId = request.ProgressConditionId;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
