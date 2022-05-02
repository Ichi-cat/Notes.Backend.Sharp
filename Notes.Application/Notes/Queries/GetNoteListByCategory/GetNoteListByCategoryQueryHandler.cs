﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
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
            //сущ ли категория
            //проверить
            var category = await _context.Categories.Include(x => x.Notes)
                .FirstOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken);
            if (category == null || category.UserId != request.UserId)
                throw new NotFoundException();

            var notes = category.Notes.Select(x => _mapper.Map<NoteDto>(x)).ToList();

            //var notes = await _context.Notes.Where(x => x.UserId == request.UserId
            //    && x.CategoryId == request.CategoryId)
            //    .ProjectTo<NoteDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync();
            return new NoteListDto { Notes = notes };
        }
    }
}
