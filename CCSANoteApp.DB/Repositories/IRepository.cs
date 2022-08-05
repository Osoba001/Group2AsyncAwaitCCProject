using CCSANoteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSANoteApp.DB.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> Add(T entity);
        Task<T>? GetById(Guid id);
        Task<List<T>> GetAll();
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> DeleteById(Guid id);

    }
}
