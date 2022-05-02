using MediatR;
using System;

namespace Notes.Application.NoteTasks.Commands.DeleteNoteTask
{
    public class DeleteNoteTaskCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
