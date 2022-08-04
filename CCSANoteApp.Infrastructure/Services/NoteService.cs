using CCSANoteApp.DB.Repositories;
using CCSANoteApp.Domain;
using CCSANoteApp.Domain.DTOs;
using NHibernate.Linq;

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
            var creator = await _userRepository.GetById(creatorUserId).FirstOrDefaultAsync();
            var note = new Note
            {
                Title = title,
                Content = content,
                NoteCreator = creator,
                GroupName = groupName
            };
           return await _noteRepository.Add(note);
        }

        public async Task<bool> DeleteNote(Guid id)
        {
            var note =await _noteRepository.GetById(id).FirstOrDefaultAsync();
            if (note != null)
            {
             return await _noteRepository.Delete(note);
            }
            return false;
        }

        public async Task<bool> DeleteNote(List<Guid> noteIds)
        {
            int nDelete=0;
            foreach (var id in noteIds)
            {
                if (await DeleteNote(id))
                {
                    nDelete++;
                }
            }
            return nDelete>0;
        }

        public async Task<List<FetchNoteDto>> FetchNote()
        {
            var notes = await _noteRepository.GetAll().ToListAsync();
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
            return await _noteRepository.FetchUserNotesByGroup(userId, groupName);
            
        }

        public async Task<Note> FetchNoteById(Guid id)
        {
           return await _noteRepository.GetById(id).FirstOrDefaultAsync();
            
            
        }

        public async Task<List<Note>> FetchNoteByUser(Guid creatorId)
        {
            return await _noteRepository.FetchUserNotes(creatorId);
        }

        public async Task<bool> UpdateNote(Guid id, string title, string content, GroupName group)
        {
            var _note =await _noteRepository.GetById(id).FirstOrDefaultAsync();
            if (_note != null)
            {
                _note.Title = title;
                _note.Content = content;
                _note.GroupName = group;
                return await _noteRepository.Update(_note);
            }
            return false;
        }

        public async Task<bool> UpdateNoteTitle(Guid id, string title)
        {
            var _note =await _noteRepository.GetById(id).FirstOrDefaultAsync();
            if (_note != null)
            {
                _note.Title = title;
               return await _noteRepository.Update(_note);
            }
            return false;
        }

    }
}
