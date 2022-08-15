using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.NoteTasks.Queries
{
    public class NoteTaskDto : IMapWith<NoteTask>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int? Seconds { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NoteTask, NoteTaskDto>();
        }
    }
}