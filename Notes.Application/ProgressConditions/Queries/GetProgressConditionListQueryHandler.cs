using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.ProgressConditions.Queries
{
    public class GetProgressConditionListQueryHandler : IRequestHandler<GetProgressConditionListQuery, ProgressConditionListDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetProgressConditionListQueryHandler(INotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProgressConditionListDto> Handle(GetProgressConditionListQuery request, CancellationToken cancellationToken)
        {
            var progressConditions = await _context.ProgressConditions
                .ProjectTo<ProgressConditionDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new ProgressConditionListDto { ProgressConditions = progressConditions };
        }
    }
}
