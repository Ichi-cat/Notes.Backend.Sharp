using MediatR;
using System;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListDto>
    {
        public Guid UserId { get; set; }
    }
}
