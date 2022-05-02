using Microsoft.AspNetCore.Mvc;
using Notes.Api.Models.Note;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Notes.Queries.GetNoteListByCategory;
using System;
using System.Threading.Tasks;

namespace Notes.Api.Controllers
{
    public class NoteController : BaseController
    {
        //private readonly IMapper mapper;

        //public NoteController(IMapper mapper)
        //{
        //    this.mapper = mapper;
        //}
        [HttpGet]
        public async Task<ActionResult<NoteListDto>> Get()
        {
            var command = new GetNoteListQuery
            {
                UserId = UserId
            };
            var notes = await Mediator.Send(command);
            return Ok(notes);
        }
        [HttpGet("ByCategory/{id}")]
        public async Task<ActionResult<NoteListDto>> GetByCategoryId(Guid id)
        {
            var command = new GetNoteListByCategoryQuery
            {
                CategoryId = id,
                UserId = UserId
            };
            var notes = await Mediator.Send(command);
            return Ok(notes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsDto>> Get(Guid id)
        {
            var command = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var note = await Mediator.Send(command);
            return Ok(note);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateNoteVm model)
        {
            var command = Mapper.Map<CreateNoteCommand>(model);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Created("", id);
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateNoteVm model)
        {
            var command = Mapper.Map<UpdateNoteCommand>(model);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                UserId = UserId,
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();//rest codes
        }
    }
}
