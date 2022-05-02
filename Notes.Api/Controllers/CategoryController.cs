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
        [HttpGet]
        public async Task<ActionResult<CategoryListDto>> Get()
        {
            var command = new GetCategoryListCommand { UserId = UserId };
            var categories = await Mediator.Send(command);
            return Ok(categories);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateCategoryVm model)
        {
            var command = Mapper.Map<CreateCategoryCommand>(model);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Created("", id);//
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateCategoryVm model)
        {
            var command = Mapper.Map<UpdateCategoryCommand>(model);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
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
