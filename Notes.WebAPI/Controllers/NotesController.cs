using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNotesList;
using Notes.WebAPI.Models;

namespace Notes.WebAPI.Controllers
{
    
    public class NotesController:BaseController
    {
        private readonly IMapper _mapper;

        public NotesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteLookUpDto>>> GetAll()
        {
            var query = new GetNotesListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return vm; 
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> Get(int id)
        {
            var query = new GetNoteDetailsQuery
            {
                Id = id,
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create([FromBody] CreateNoteDto note)
        {
            var command = _mapper.Map<CreateNoteCommand>(note);
            command.UserId = UserId;
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody] UpdateNoteDto note)
        {
            var command = _mapper.Map<UpdateNoteCommand>(note);
            command.UserId = UserId;
            await Mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{noteId}")]
        [Authorize]
        public async Task<ActionResult<int>> Delete([FromBody] int noteId)
        {
            var command = new DeleteNoteCommand
            {
                Id = noteId,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}