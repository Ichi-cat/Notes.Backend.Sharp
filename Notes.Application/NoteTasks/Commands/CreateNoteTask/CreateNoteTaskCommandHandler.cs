using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.NoteTasks.Commands.CreateNoteTask
{
    public class CreateNoteTaskCommandHandler : IRequestHandler<CreateNoteTaskCommand, Guid>
    {
        private readonly INotesDbContext _context;

        public CreateNoteTaskCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateNoteTaskCommand request, CancellationToken cancellationToken)
        {
            var noteTask = new NoteTask
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Name = request.Name,
                Text = request.Text,
                Seconds = request.Seconds,
                Date = request.DateTime,
                MatrixId = request.MatrixId,
                ProgressConditionId = request.ProgressConditionId
            };
            await _context.Tasks.AddAsync(noteTask, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return noteTask.Id;
        }
    }
}
