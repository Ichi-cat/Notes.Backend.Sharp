using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Notes.Domain;
using System;

namespace Notes.Application.NoteTasks.Commands.UpdateNoteTaskPatch
{
    public class UpdateNoteTaskPatchCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public JsonPatchDocument<NoteTask> Model { get; set; }
    }
}
