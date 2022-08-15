using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.Notes.Queries
{
    public class NoteDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDto>();
        }
    }
}