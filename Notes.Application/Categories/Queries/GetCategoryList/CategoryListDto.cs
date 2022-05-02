using System.Collections.Generic;

namespace Notes.Application.Categories.Queries.GetCategoryList
{
    public class CategoryListDto
    {
        public IList<CategoryDto> Categories { get; set; }
    }
}