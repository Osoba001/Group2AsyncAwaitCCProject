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

        public async Task CreateNote(Note note)
        {
            await _noteRepository.Add(note);
        }

        public async Task CreateNote(Guid creatorUserId, string title, string content, GroupName groupName)
        {
            var creator = await _userRepository.GetById(creatorUserId);
            var note = new Note
            {
                Title = title,
                Content = content,
                NoteCreator = creator,
                GroupName = groupName
            };
            await _noteRepository.Add(note);
        }

        public async Task DeleteNote(Guid id)
        {
            var note = await _noteRepository.GetById(id);
            if (note != null)
            {
               await _noteRepository.Delete(note);
            }
        }

        public async Task DeleteNote(List<Guid> noteIds)
        {
            foreach (var id in noteIds)
            {
                await DeleteNote(id);
            }
        }

        public async Task<List<FetchNoteDto>> FetchNote()
        {
            var notes = await _noteRepository.GetAll();
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
            return result;
        }

        public async Task<List<Note>> FetchUserNotesByGroup(Guid userId, GroupName groupName)
        {
            var _notes = await _noteRepository.FetchUserNotesByGroup(userId, groupName);
            return _notes;
        }

        public async Task<Note> FetchNoteById(Guid id)
        {
            var note = await _noteRepository.GetById(id);
            return note;
        }

        public async Task<List<Note>> FetchNoteByUser(Guid creatorId)
        {
            var notes = await _noteRepository.FetchUserNotes(creatorId);
            return notes;
        }

        public async Task UpdateNote(Guid id, string title, string content, GroupName group)
        {
            var _note = await _noteRepository.GetById(id);
            if (_note != null)
            {
                _note.Title = title;
                _note.Content = content;
                _note.GroupName = group;
                await _noteRepository.Update(_note);
            }
        }

        public async Task UpdateNoteTitle(Guid id, string title)
        {
            var _note = await _noteRepository.GetById(id);
            if (_note != null)
            {
                _note.Title = title;
                await _noteRepository.Update(_note);
            }
        }

    }
}
