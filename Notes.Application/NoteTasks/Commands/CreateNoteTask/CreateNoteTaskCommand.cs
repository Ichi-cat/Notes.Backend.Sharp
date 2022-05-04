using MediatR;
using Notes.Domain;
using System;

namespace Notes.Application.NoteTasks.Commands.CreateNoteTask
{
    public class CreateNoteTaskCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Seconds { get; set; }
        public DateTime? DateTime { get; set; }//
        public MatricesEnum? MatrixId { get; set; }//
        public ProgressConditionEnum? ProgressConditionId { get; set; }
    }
}
