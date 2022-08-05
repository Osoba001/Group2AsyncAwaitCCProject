using CCSANoteApp.Domain;
using CCSANoteApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        public INoteService NoteService { get; }
        public NotesController(INoteService databaseService)
        {
            NoteService = databaseService;
        }

        [HttpPost("create-note")]
        public async Task<IActionResult> CreateNote([FromBody]NoteDto note)
        {
            return Ok(await NoteService.CreateNote(note.CreatorUserId, note.Title, note.Content, note.GroupName));

        }

        
        [HttpDelete]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            return Ok(await NoteService.DeleteNote(id));
        }

        [HttpDelete("multiple")]
        public async Task<IActionResult> DeleteNote([FromBody]List<Guid> noteIds)
        {
            
            return Ok(await NoteService.DeleteNote(noteIds));
        }
        [HttpGet("note")]
        public async Task<IActionResult> FetchNote()
        {
            return Ok(await NoteService.FetchNote());
        }
        [HttpGet("note-group")]
        public async Task<IActionResult> FetchNoteByGroup(Guid userId, GroupName groupName)
        {
            return Ok(await NoteService.FetchUserNotesByGroup(userId,groupName));
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> FetchNoteById(Guid id)
        {
            return Ok(await NoteService.FetchNoteById(id));
        }

        [HttpGet("by-user/{id}")]
        public async Task<IActionResult> FetchNoteByUser(Guid id)
        {
            return Ok(await NoteService.FetchNoteByUser(id));
        }

        [HttpPut("title")]
        public async Task<IActionResult> UpdateNoteTitle(Guid id, string title)
        {
            
            return Ok(await NoteService.UpdateNoteTitle(id, title));
        }
    }
}
