using AutoMapper;
using Notes.Application.Categories.Commands.CreateCategory;
using Notes.Application.Common.Mappings;

namespace Notes.Api.Models.Category
{
    public class CreateCategoryVm : IMapWith<CreateCategoryCommand>
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryVm, CreateCategoryCommand>();
        }
    }
}
