using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly INotesDbContext _context;

        public DeleteCategoryCommandHandler(INotesDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (category == null || category.UserId != request.UserId)
                throw new NotFoundException(nameof(Category), request.Id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
