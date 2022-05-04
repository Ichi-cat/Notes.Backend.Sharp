using Microsoft.AspNetCore.Mvc;
using Notes.Api.Models.NoteTask;
using Notes.Application.NoteTasks.Commands.CreateNoteTask;
using Notes.Application.NoteTasks.Commands.DeleteNoteTask;
using Notes.Application.NoteTasks.Commands.UpdateNoteTask;
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
        [HttpGet]
        public async Task<ActionResult<NoteTaskListDto>> Get()
        {
            var query = new GetNoteTaskListQuery
            {
                UserId = UserId
            };
            var tasks = await Mediator.Send(query);
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteTaskDetailsDto>> Get(Guid id)
        {
            var query = new GetNoteTaskDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var taskDetails = await Mediator.Send(query);
            return Ok(taskDetails);
        }
        [HttpGet("bymatrix/{id}")]
        public async Task<ActionResult<NoteTaskListDto>> GetByMatrix(MatricesEnum id)
        {
            var query = new GetNoteTaskListByMatrixQuery
            {
                UserId = UserId,
                MatrixId = id
            };
            var tasks = await Mediator.Send(query);
            return Ok(tasks);

        }
        [HttpGet("byprogresscondition/{id}")]
        public async Task<ActionResult<NoteTaskListDto>> GetByProgressCondition(ProgressConditionEnum id)
        {
            var query = new GetNoteTaskListByProgressConditionQuery
            {
                UserId = UserId,
                ProgressConditionId = id
            };
            var tasks = await Mediator.Send(query);
            return Ok(tasks);

        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateNoteTaskVm model)
        {
            var command = Mapper.Map<CreateNoteTaskCommand>(model);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Created("", id);
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateNoteTaskVm model)
        {
            var command = Mapper.Map<UpdateNoteTaskCommand>(model);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
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
