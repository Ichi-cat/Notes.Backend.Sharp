﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskList
{
    public class GetNoteTaskListQueryHandler : IRequestHandler<GetNoteTaskListQuery, NoteTaskListDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteTaskListQueryHandler(INotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<NoteTaskListDto> Handle(GetNoteTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks.Where(x => x.UserId == request.UserId)
                .ProjectTo<NoteTaskDto>(_mapper.ConfigurationProvider).ToListAsync();
            return new NoteTaskListDto { Tasks = tasks };
        }
    }
}
