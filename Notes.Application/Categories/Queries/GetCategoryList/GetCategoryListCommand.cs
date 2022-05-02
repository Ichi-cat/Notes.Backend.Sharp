using MediatR;
using System;

namespace Notes.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListCommand : IRequest<CategoryListDto>
    {
        public Guid UserId { get; set; }
    }
}
