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
        public IActionResult CreateNote([FromBody] NoteDto note)
        {
            NoteService.CreateNote(note.creatorUserId,note.Title, note.Content, note.GroupName);
            return Ok("Created Successfully");
        }

        
        [HttpDelete]
        public IActionResult DeleteNote(Guid id)
        {
            NoteService.DeleteNote(id);
            return Ok("Deleted Successfully");
        }

        [HttpDelete("multiple")]
        public IActionResult DeleteNote([FromBody]List<Guid> noteIds)
        {
            NoteService.DeleteNote(noteIds);
            return Ok("Deleted Successfully");
        }
        [HttpGet("note")]
        public IActionResult FetchNote()
        {
            return Ok(NoteService.FetchNote());
        }
        [HttpGet("note-group")]
        public IActionResult FetchNoteByGroup(Guid userId, GroupName groupName)
        {
            return Ok(NoteService.FetchUserNotesByGroup(userId,groupName));
        }

        [HttpGet("by-id/{id}")]
        public IActionResult FetchNoteById(Guid id)
        {
            return Ok(NoteService.FetchNoteById(id));
        }

        [HttpGet("by-user/{id}")]
        public IActionResult FetchNoteByUser(Guid id)
        {
            return Ok(NoteService.FetchNoteByUser(id));
        }

        [HttpPut("title")]
        public IActionResult UpdateNoteTitle(Guid id, string title)
        {
            NoteService.UpdateNoteTitle(id, title);
            return Ok("Updated Successfully");
        }
    }
}
