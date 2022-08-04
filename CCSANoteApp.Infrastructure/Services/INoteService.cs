using CCSANoteApp.Domain;
using CCSANoteApp.Domain.DTOs;

namespace CCSANoteApp.Infrastructure
{
    public interface INoteService
    {
        Task CreateNote(Note note);
        Task CreateNote(Guid creatorUserId, string title, string content,GroupName groupName);
        Task UpdateNoteTitle(Guid id, string title);
        Task DeleteNote(Guid id);
        Task DeleteNote(List<Guid> notes);
        Task<List<FetchNoteDto>> FetchNote();
        Task<List<Note>> FetchNoteByUser(Guid id);
        Task<Note> FetchNoteById(Guid id);
        Task<List<Note>> FetchUserNotesByGroup(Guid userId, GroupName groupName);
    }
}
