using MediatR;
using System;

namespace Notes.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
