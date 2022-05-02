using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;
using System;

namespace Notes.Api.Models.Note
{
    public class UpdateNoteVm : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteVm, UpdateNoteCommand>();
        }
    }
}
