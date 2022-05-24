using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.Api.Models.Category;
using Notes.Application.Categories.Commands.CreateCategory;
using Notes.Application.Categories.Commands.DeleteCategory;
using Notes.Application.Categories.Commands.UpdateCategory;
using Notes.Application.Categories.Queries.GetCategoryList;
using System;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    public class CategoryController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult<CategoryListDto>> GetCategories()
        {
            var command = new GetCategoryListCommand { UserId = UserId };
            var categories = await Mediator.Send(command);
            return Ok(categories);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCategory(CreateCategoryVm model)
        {
            var command = Mapper.Map<CreateCategoryCommand>(model);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Created("", id);//
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public async Task<ActionResult> UpdateCategory(UpdateCategoryVm model)
        {
            var command = Mapper.Map<UpdateCategoryCommand>(model);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var command = new DeleteCategoryCommand
            {
                UserId = UserId,
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
