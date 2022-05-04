using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskDetails
{
    public class NoteTaskDetailsDto : IMapWith<NoteTask>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int? Seconds { get; set; }
        public DateTime? Date { get; set; }
        public MatricesEnum? MatrixId { get; set; }
        public ProgressConditionEnum? ProgressConditionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NoteTask, NoteTaskDetailsDto>();
        }
    }
}