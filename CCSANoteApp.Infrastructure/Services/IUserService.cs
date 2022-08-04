using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure
{
    public interface IUserService
    {
        Task CreateUser(string username, string email, string password);
        Task CreateUser(User user);
        Task UpdateUserName(Guid id, string name);
        Task UpdateUserEmail(Guid id, string email);
        Task DeleteUser(Guid id);
        Task<UserDto> GetUser(Guid id);
        Task<List<User>> GetUsers();
    }
}
