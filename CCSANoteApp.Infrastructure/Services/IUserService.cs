using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure
{
    public interface IUserService
    {
        Task<bool> CreateUser(string username, string email, string password);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUserName(Guid id, string name);
        Task<bool> UpdateUserEmail(Guid id, string email);
        Task<bool> DeleteUser(Guid id);
        Task<IQueryable<User>> GetUser(Guid id);
        Task<IQueryable<User>> GetUsers();
    }
}
