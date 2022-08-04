using CCSANoteApp.DB.Repositories;
using CCSANoteApp.Domain;
using CCSANoteApp.Domain.DTOs;

namespace CCSANoteApp.Infrastructure
{
    public class NoteService : INoteService
    {
        private readonly NoteRepository _noteRepository;
        private readonly UserRepository _userRepository;

        public NoteService(NoteRepository noteRepository, UserRepository userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateNote(Note note)
        {
            return await _noteRepository.Add(note);
        }

        public async Task<bool> CreateNote(Guid creatorUserId, string title, string content, GroupName groupName)
        {
            var creator =  _userRepository.GetById(creatorUserId);
            var note = new Note
            {
                Title = title,
                Content = content,
                NoteCreator = creator,
                GroupName = groupName
            };
            await _noteRepository.Add(note);
        }

        public async Task<bool> DeleteNote(Guid id)
        {
            var note =  _noteRepository.GetById(id);
            
            
               return await _noteRepository.Delete(note);
            

        }

        public async Task<bool> DeleteNote(List<Guid> noteIds)
        {
            foreach (var id in noteIds)
            {
                await DeleteNote(id);
            }
            return true;
        }

        public async Task<IQueryable<FetchNoteDto>> FetchNote()
        {
            var notes = _noteRepository.GetAll();
            var result = new List<FetchNoteDto>();
            foreach (var note in notes)
            {
                result.Add(new FetchNoteDto
                {
                    Content = note.Content,
                    CreatedDate = note.CreatedDate,
                    creatorUserId = note.NoteCreator.Id,
                    GroupName = note.GroupName,
                    Title = note.Title,
                    UpdatedDate = note.UpdatedDate
                });
            }
            return result.AsQueryable();
        }

        public async Task<IQueryable<Note>> FetchUserNotesByGroup(Guid userId, GroupName groupName)
        {
            var _notes =  _noteRepository.FetchUserNotesByGroup(userId, groupName);
            return _notes.AsQueryable();
        }

        public async Task<IQueryable<Note>> FetchNoteById(Guid id)
        {
            var note =  _noteRepository.GetById(id);
            return note;
        }

        public async Task<IQueryable<Note>> FetchNoteByUser(Guid creatorId)
        {
            var notes = _noteRepository.FetchUserNotes(creatorId);
            return notes.AsQueryable();
        }

        public async Task<bool> UpdateNote(Guid id, string title, string content, GroupName group)
        {
            var _note = _noteRepository.GetById(id);
            
           
                //_note.Title = title;
                //_note.Content = content;
                //_note.GroupName = group;
                return await _noteRepository.Update(_note);
            
        }

        public async Task<bool> UpdateNoteTitle(Guid id, string title)
        {
            var _note =  _noteRepository.GetById(id);
            
            
                //.Title = title;
                return await _noteRepository.Update(_note);
            
        }

    }
}
