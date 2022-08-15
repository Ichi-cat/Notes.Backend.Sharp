using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.NoteTasks.Queries.GetNoteTaskDetails
{
    public class GetNoteTaskDetailsQueryHandler : IRequestHandler<GetNoteTaskDetailsQuery, NoteTaskDetailsDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteTaskDetailsQueryHandler(INotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<NoteTaskDetailsDto> Handle(GetNoteTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var taskDetail = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            //taskDetail.Date = DateTime.SpecifyKind(taskDetail.Date.Value, DateTimeKind.Utc);
            if (taskDetail == null || taskDetail.UserId != request.UserId)
                throw new NotFoundException(nameof(NoteTask), request.Id);
            return _mapper.Map<NoteTaskDetailsDto>(taskDetail);
        }
    }
}
