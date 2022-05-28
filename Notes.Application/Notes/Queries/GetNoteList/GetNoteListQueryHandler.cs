using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, NoteListDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(INotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<NoteListDto> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notes = await _context.Notes.Where(x => x.UserId == request.UserId)
                .ProjectTo<NoteDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new NoteListDto { Notes = notes };
        }
    }
}
