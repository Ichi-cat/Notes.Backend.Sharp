using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Notes.Domain;
using System;

namespace Notes.Application.Notes.Commands.UpdateNotePatch
{
    public class UpdateNotePatchCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public JsonPatchDocument<Note> Model { get; set; }
    }
}
