using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Notes.Api.Models.NoteTask;
using Notes.Application.NoteTasks.Commands.CreateNoteTask;
using Notes.Application.NoteTasks.Commands.DeleteNoteTask;
using Notes.Application.NoteTasks.Commands.UpdateNoteTask;
using Notes.Application.NoteTasks.Commands.UpdateNoteTaskPatch;
using Notes.Application.NoteTasks.Queries;
using Notes.Application.NoteTasks.Queries.GetNoteTaskDetails;
using Notes.Application.NoteTasks.Queries.GetNoteTaskList;
using Notes.Application.NoteTasks.Queries.GetNoteTaskListByMatrix;
using Notes.Application.NoteTasks.Queries.GetNoteTaskListByProgressCondition;
using Notes.Domain;
using System;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    public class NoteTaskController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<ActionResult<NoteTaskListDto>> GetNoteTasks()
        {
            var query = new GetNoteTaskListQuery
            {
                UserId = UserId
            };
            var tasks = await Mediator.Send(query);
            return Ok(tasks);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteTaskDetailsDto>> GetNoteTaskById(Guid id)
        {
            var query = new GetNoteTaskDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var taskDetails = await Mediator.Send(query);
            //taskDetails.Date = DateTime.SpecifyKind(taskDetails.Date.Value, DateTimeKind.Utc);
            return Ok(taskDetails);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("bymatrix/{id}")]
        public async Task<ActionResult<NoteTaskListDto>> GetNoteTaskByMatrix(MatricesEnum id)
        {
            var query = new GetNoteTaskListByMatrixQuery
            {
                UserId = UserId,
                MatrixId = id
            };
            var tasks = await Mediator.Send(query);
            return Ok(tasks);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("byprogresscondition/{id}")]
        public async Task<ActionResult<NoteTaskListDto>> GetNoteTaskByProgressCondition(ProgressConditionEnum id)
        {
            var query = new GetNoteTaskListByProgressConditionQuery
            {
                UserId = UserId,
                ProgressConditionId = id
            };
            var tasks = await Mediator.Send(query);
            return Ok(tasks);

        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNoteTask(CreateNoteTaskVm model)
        {
            var command = Mapper.Map<CreateNoteTaskCommand>(model);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Created("", id);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public async Task<ActionResult> UpdateNoteTask(UpdateNoteTaskVm model)
        {
            var command = Mapper.Map<UpdateNoteTaskCommand>(model);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateNoteTaskPatch(JsonPatchDocument<NoteTask> model, Guid id)
        {
            var command = new UpdateNoteTaskPatchCommand
            {
                Id = id,
                UserId = UserId,
                Model = model
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNoteTask(Guid id)
        {
            var command = new DeleteNoteTaskCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
