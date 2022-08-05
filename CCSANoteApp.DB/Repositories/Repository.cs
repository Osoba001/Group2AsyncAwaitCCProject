using CCSANoteApp.Domain;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSANoteApp.DB.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ISession _session;

        public Repository(SessionFactory sessionFactory)
        {
            _session = sessionFactory.GetSession();
        }
        public async Task<bool> Add(T entity)
        {
            await _session.SaveAsync(entity);
            return await Commit();
        }

        public async Task<bool> Delete(T entity)
        {
            await _session.DeleteAsync(entity);
            return await Commit();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var ent = await _session.Query<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (ent != null)
            {
                 _session.Delete(ent);
                return await Commit();

            }
            return false;
        }

        public async Task<List<T>> GetAll()
        {
            return await _session.Query<T>().ToListAsync();
        }

        public async Task<T>? GetById(Guid id)
        {
            return await _session.Query<T>().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<bool> Update(T entity)
        {
            await _session.UpdateAsync(entity);
            return await Commit();
        }

        protected async Task<bool> Commit()
        {
            using var transction = _session.BeginTransaction();
            try
            {
                if (transction.IsActive)
                {
                    _session.Flush();
                    await transction.CommitAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                transction.Rollback();
                return false;
            }
        }
    }
}
