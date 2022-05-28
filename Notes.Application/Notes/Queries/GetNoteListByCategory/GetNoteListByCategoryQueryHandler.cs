using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteListByCategory
{
    public class GetNoteListByCategoryQueryHandler : IRequestHandler<GetNoteListByCategoryQuery, NoteListDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteListByCategoryQueryHandler(INotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<NoteListDto> Handle(GetNoteListByCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Include(x => x.Notes)
                .FirstOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken);
            if (category == null || category.UserId != request.UserId)
                throw new NotFoundException(nameof(Category), request.CategoryId);
            var notes = category.Notes.Select(x => _mapper.Map<NoteDto>(x)).ToList();
            return new NoteListDto { Notes = notes };
        }
    }
}
