using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListCommandHandler : IRequestHandler<GetCategoryListCommand, CategoryListDto>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryListCommandHandler(INotesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoryListDto> Handle(GetCategoryListCommand request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.Where(x => x.UserId == request.UserId)
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new CategoryListDto { Categories = categories };
        }
    }
}
