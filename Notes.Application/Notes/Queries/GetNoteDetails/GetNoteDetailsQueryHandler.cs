using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(INotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<NoteDetailsDto> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null || entity.UserId != request.UserId)
                throw new NotFoundException(nameof(Note), request.Id);
            return _mapper.Map<NoteDetailsDto>(entity);
        }
    }
}
