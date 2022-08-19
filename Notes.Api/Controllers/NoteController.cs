using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Notes.Api.Models.Note;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Commands.UpdateNotePatch;
using Notes.Application.Notes.Queries;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Notes.Queries.GetNoteListByCategory;
using Notes.Domain;
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
        /// <summary>
        /// Gets the list of Note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        /// <returns>Returnas NoteListDto</returns>
        /// <response code="200">Success</response>
        /// <response code="401">User is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NoteListDto>> GetNotes()
        {
            var command = new GetNoteListQuery
            {
                UserId = UserId
            };
            var notes = await Mediator.Send(command);
            return Ok(notes);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("ByCategory/{id}")]
        public async Task<ActionResult<NoteListDto>> GetNotesByCategoryId(Guid id)
        {
            var command = new GetNoteListByCategoryQuery
            {
                CategoryId = id,
                UserId = UserId
            };
            var notes = await Mediator.Send(command);
            return Ok(notes);
        }
        /// <summary>
        /// Gets the Note by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note/66CF06F5-568E-4490-993C-356751BA6CC6
        /// </remarks>
        /// <param name="id">Note id(Guid)</param>
        /// <returns>Returns NoteDetailsDto</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsDto>> GetNoteById(Guid id)
        {
            var command = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var note = await Mediator.Send(command);
            return Ok(note);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteVm model)
        {
            var command = Mapper.Map<CreateNoteCommand>(model);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Created("", id);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        public async Task<ActionResult> UpdateNote(UpdateNoteVm model)
        {
            var command = Mapper.Map<UpdateNoteCommand>(model);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateNotePatch(JsonPatchDocument<Note> model, Guid id)
        {
            var command = new UpdateNotePatchCommand
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
        public async Task<ActionResult> DeleteNote(Guid id)
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
