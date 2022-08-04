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
        Task<IQueryable<FetchNoteDto>> FetchNote();
        Task<IQueryable<Note>> FetchNoteByUser(Guid id);
        Task<IQueryable<Note>> FetchNoteById(Guid id);
        Task<IQueryable<Note>> FetchUserNotesByGroup(Guid userId, GroupName groupName);
    }
}
