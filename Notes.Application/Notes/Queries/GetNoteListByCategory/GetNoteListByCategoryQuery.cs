using MediatR;
using System;

namespace Notes.Application.Notes.Queries.GetNoteListByCategory
{
    public class GetNoteListByCategoryQuery : IRequest<NoteListDto>
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
