using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.NoteTasks.Commands.CreateNoteTask;
using Notes.Domain;
using System;

namespace Notes.Api.Models.NoteTask
{
    public class CreateNoteTaskVm : IMapWith<CreateNoteTaskCommand>
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Seconds { get; set; }
        public DateTime? Date { get; set; }
        public MatricesEnum? MatrixId { get; set; }
        public ProgressConditionEnum? ProgressConditionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteTaskVm, CreateNoteTaskCommand>().
                ForMember(destination => destination.DateTime, opt => opt.MapFrom(source => source.Date));
        }
    }
}
