using CCSANoteApp.Domain;
using NHibernate;
using NHibernate.Linq;

namespace CCSANoteApp.DB.Repositories
{
    public class NoteRepository : Repository<Note>
    {
        private readonly ISession _session;
        public NoteRepository(SessionFactory sessionFactory) : base(sessionFactory)
        {
            _session=sessionFactory.GetSession();
        }

        public async Task<List<Note>> FetchUserNotesByGroup(Guid userId, GroupName groupName)
        {
            var notes = _session.Query<Note>().Where(x => x.NoteCreator.Id == userId && x.GroupName == groupName);
            return await notes.ToListAsync();
        }

        public Task<List<Note>> FetchUserNotes(Guid userId)
        {
            var notes = _session.Query<Note>().Where(x => x.NoteCreator.Id == userId);
            return notes.ToListAsync();
        }
    }
}
