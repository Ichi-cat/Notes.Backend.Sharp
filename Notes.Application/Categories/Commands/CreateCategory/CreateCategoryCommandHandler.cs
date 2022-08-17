using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly INotesDbContext _context;

        public CreateCategoryCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Color = request.Color,
                UserId = request.UserId
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }
    }
}
