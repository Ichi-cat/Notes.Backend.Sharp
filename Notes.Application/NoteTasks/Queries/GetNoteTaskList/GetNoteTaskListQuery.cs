using MediatR;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskList
{
    public class GetNoteTaskListQuery : IRequest<NoteTaskListDto>
    {
        public Guid UserId { get; set; }
    }
}
