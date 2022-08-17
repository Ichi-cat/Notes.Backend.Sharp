using AutoMapper;
using Notes.Application.Categories.Commands.UpdateCategory;
using Notes.Application.Common.Mappings;
using System;

namespace Notes.Api.Models.Category
{
    public class UpdateCategoryVm : IMapWith<UpdateCategoryCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCategoryVm, UpdateCategoryCommand>();
        }
    }
}
