using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly INotesDbContext _context;

        public UpdateCategoryCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (category == null || category.UserId != request.UserId)
                throw new NotFoundException(nameof(Category), request.Id);
            category.Name = request.Name;
            category.Color = request.Color;
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
