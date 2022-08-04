using CCSANoteApp.Domain;
using CCSANoteApp.Domain.DTOs;

namespace CCSANoteApp.Infrastructure
{
    public interface INoteService
    {
        Task<bool> CreateNote(Note note);
        Task<bool> CreateNote(Guid creatorUserId, string title, string content,GroupName groupName);
        Task<bool> UpdateNoteTitle(Guid id, string title);
        Task<bool> DeleteNote(Guid id);
        Task<bool> DeleteNote(List<Guid> notes);
        Task<List<FetchNoteDto>> FetchNote();
        Task<List<Note>> FetchNoteByUser(Guid id);
        Task<Note> FetchNoteById(Guid id);
        Task<List<Note>> FetchUserNotesByGroup(Guid userId, GroupName groupName);
    }
}
