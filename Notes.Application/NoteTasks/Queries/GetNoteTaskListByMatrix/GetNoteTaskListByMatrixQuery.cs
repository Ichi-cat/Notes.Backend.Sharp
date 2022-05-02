using MediatR;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskListByMatrix
{
    public class GetNoteTaskListByMatrixQuery : IRequest<NoteTaskListDto>
    {
        public Guid MatrixId { get; set; }
        public Guid UserId { get; set; }
    }
}
