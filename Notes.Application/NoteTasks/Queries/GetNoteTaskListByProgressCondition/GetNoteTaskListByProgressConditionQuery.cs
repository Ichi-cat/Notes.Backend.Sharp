using MediatR;
using Notes.Domain;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskListByProgressCondition
{
    public class GetNoteTaskListByProgressConditionQuery : IRequest<NoteTaskListDto>
    {
        public ProgressConditionEnum ProgressConditionId { get; set; }
        public Guid UserId { get; set; }
    }
}
