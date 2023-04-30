using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.NoteApp.Appication.Notes.Create;
using Serdiuk.NoteApp.Appication.Notes.Delete;
using Serdiuk.NoteApp.Appication.Notes.Edit;
using Serdiuk.NoteApp.Appication.Notes.GetById;
using Serdiuk.NoteApp.Appication.Notes.GetNoteList;
using Serdiuk.NoteApp.Infrastructure.Base;

namespace Serdiuk.NoteApp.WebApi.Controllers
{
    [Authorize]
    public class NoteController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetNoteByIdQuery { Id = id, UserId = UserId }, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(o => o.Message));

            return Ok(result.Value);
        }
        [HttpGet]
        public async Task<IActionResult> GetNotes([FromQuery]GetNoteListQueryDto request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetNoteListQuery { PageNumber = request.PageNumber, UserId = UserId }, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(o=>o.Message));

            return Ok(result.Value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNote(CreateNoteCommandDto request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new CreateNoteCommand {Title = request.Title, Details = request.Details, UserId = UserId }, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(o => o.Message));

            return Ok(result.Value);
        }
        [HttpPut]
        public async Task<IActionResult> EditNote(EditNoteCommandDto request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new EditNoteCommand { Title = request.Title, Details = request.Details, UserId = UserId, Id = request.Id }, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(o => o.Message));

            return Ok(result.Value);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteNote([FromQuery]DeleteNoteCommandDto request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new DeleteNoteCommand { UserId = UserId, Id = request.Id }, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons.Select(o => o.Message));

            return Ok();
        }
    }
}
