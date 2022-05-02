using MediatR;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskDetails
{
    public class GetNoteTaskDetailsQuery : IRequest<NoteTaskDetailsDto>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
