using MediatR;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskListByMatrix
{
    public class GetNoteTaskListByMatrixQuery : IRequest<NoteTaskListDto>
    {
        public MatricesEnum MatrixId { get; set; }
        public Guid UserId { get; set; }
    }
}
