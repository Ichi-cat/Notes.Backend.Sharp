using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskListByMatrix
{
    public class GetNoteTaskListByMatrixQueryHandler : IRequestHandler<GetNoteTaskListByMatrixQuery, NoteTaskListDto>
    {
        public Task<NoteTaskListDto> Handle(GetNoteTaskListByMatrixQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
