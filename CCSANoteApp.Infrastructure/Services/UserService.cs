using CCSANoteApp.DB.Repositories;
using CCSANoteApp.Domain;
using CCSANoteApp.Domain.DTOs;
using NHibernate.Linq;

namespace CCSANoteApp.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(string username, string email, string password)
        {

            return await _userRepository.Add(new User
            {
                Email = email,
                Username = username,
                Password = password
            });
        }

        public async Task<bool> CreateUser(User user)
        {
           return await _userRepository.Add(user);
        }

        public async Task<bool> DeleteUser(Guid id)
        {
           return await _userRepository.DeleteById(id);
        }

        public async Task<FetchUserDto> GetUser(Guid id)
        {
            //Refactor to add user notes
            var user = await _userRepository.GetById(id);

            var result = new FetchUserDto
            {
                
                Username = user.Username,
                Email = user.Email, 
            };
            foreach (var note in user.Notes)
            {
                result.UserNotes.Add( new FetchNoteDto() {
                    Content=note.Content, CreatedDate=note.CreatedDate,
                GroupName=note.GroupName,Title=note.Title,UpdatedDate=note.UpdatedDate});
            }
            return result;
        }

        public async Task<List<FetchUserDto>> GetUsers()
        {
            //Refactor
            var users= await _userRepository.GetAll();
            List<FetchUserDto> _user=new List<FetchUserDto>();
            foreach (var user in users)
            {
                _user.Add(new FetchUserDto() { Email = user.Email, Username = user.Username, UserId=user.Id });
            }
            return _user;
        }

        public async Task<bool> UpdateUserEmail(Guid id, string email)
        {
            throw new NotImplementedException();
            //var user = GetUser(id);
            //if (user != null)
            //{
            //    user.Email = email;
            //    _userRepository.Update(user);
            //}
        }

        public async Task<bool> UpdateUserName(Guid id, string name)
        {
            throw new NotImplementedException();
            //var user = GetUser(id);
            //if (user != null)
            //{
            //    user.Username = name;
            //    _userRepository.Update(user);
            //}
        }
    }
}
