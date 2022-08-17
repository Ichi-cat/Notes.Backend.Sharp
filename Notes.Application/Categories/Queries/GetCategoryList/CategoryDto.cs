using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.Categories.Queries.GetCategoryList
{
    public class CategoryDto : IMapWith<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDto>();
        }
    }
}