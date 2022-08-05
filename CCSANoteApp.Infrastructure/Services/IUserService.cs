using CCSANoteApp.Domain;
using CCSANoteApp.Domain.DTOs;

namespace CCSANoteApp.Infrastructure
{
    public interface IUserService
    {
        Task<bool> CreateUser(string username, string email, string password);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUserName(Guid id, string name);
        Task<bool> UpdateUserEmail(Guid id, string email);
        Task<bool> DeleteUser(Guid id);
        Task<FetchUserDto> GetUser(Guid id);
        Task<List<FetchUserDto>> GetUsers();
    }
}
