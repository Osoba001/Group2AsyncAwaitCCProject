using CCSANoteApp.Domain;
using CCSANoteApp.Domain.DTOs;

namespace CCSANoteApp.Infrastructure
{
    public interface INoteService
    {
        void CreateNote(Note note);
        void CreateNote(Guid creatorUserId, string title, string content,GroupName groupName);
        void UpdateNoteTitle(Guid id, string title);
        void DeleteNote(Guid id);
        void DeleteNote(List<Guid> notes);
        List<FetchNoteDto> FetchNote();
        List<Note> FetchNoteByUser(Guid id);
        Note FetchNoteById(Guid id);
        List<Note> FetchUserNotesByGroup(Guid userId, GroupName groupName);
    }
}
