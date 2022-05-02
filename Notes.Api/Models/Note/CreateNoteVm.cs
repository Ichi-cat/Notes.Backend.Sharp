using AutoMapper;
using Notes.Application.Notes.Commands.CreateNote;
using System;
using Notes.Application.Common.Mappings;

namespace Notes.Api.Models.Note
{
    //модель для принятия данных от пользователяя
    public class CreateNoteVm : IMapWith<CreateNoteCommand>
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Guid? CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteVm, CreateNoteCommand>();
            //.ForMember(noteCommand => noteCommand.Name,
            //    opt => opt.MapFrom(noteVm =>
            //        noteVm.Name))
            //.ForMember(noteCommand => noteCommand.Text,
            //    opt => opt.MapFrom(noteVm =>
            //        noteVm.Text));
        }
    }
}
