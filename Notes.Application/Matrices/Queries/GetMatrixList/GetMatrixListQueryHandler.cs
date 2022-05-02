using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Matrices.Queries.GetMatrixList
{
    public class GetMatrixListQueryHandler : IRequestHandler<GetMatrixListQuery, MatrixListDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetMatrixListQueryHandler(INotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MatrixListDto> Handle(GetMatrixListQuery request, CancellationToken cancellationToken)
        {
            var matrices = await _context.Matrices.ProjectTo<MatrixDto>(_mapper.ConfigurationProvider).ToListAsync();
            return new MatrixListDto { Matrices = matrices };
        }
    }
}
