using MediatR;
using System;

namespace Notes.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
