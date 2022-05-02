using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.NoteTasks.Commands.UpdateNoteTask;
using System;

namespace Notes.Api.Models.NoteTask
{
    public class UpdateNoteTaskVm : IMapWith<UpdateNoteTaskCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Seconds { get; set; }
        public DateTime? Date { get; set; }
        public int? MatrixId { get; set; }
        public int? ProgressConditionId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteTaskVm, UpdateNoteTaskCommand>();
        }
    }
}
