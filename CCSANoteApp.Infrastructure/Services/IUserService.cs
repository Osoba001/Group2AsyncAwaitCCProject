using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure
{
    public interface IUserService
    {
        void CreateUser(string username, string email, string password);
        void CreateUser(User user);
        void UpdateUserName(Guid id, string name);
        void UpdateUserEmail(Guid id, string email);
        void DeleteUser(Guid id);
        UserDto GetUser(Guid id);
        List<User> GetUsers();
    }
}
