using CCSANoteApp.DB.Repositories;
using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(string username, string email, string password)
        {
            await _userRepository.Add(new User
            {
                Email = email,
                Username = username,
                Password = password
            });
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.Add(user);
        }

        public async Task DeleteUser(Guid id)
        {
            await _userRepository.DeleteById(id);
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            //Refactor to add user notes
            var user = await _userRepository.GetById(id);

            var result = new UserDto
            {
                Username = user.Username,
                Email = user.Email
            };
            return result;
        }

        public async Task<List<User>> GetUsers()
        {
            //Refactor
            return await _userRepository.GetAll();
        }

        public async Task UpdateUserEmail(Guid id, string email)
        {
            //var user = GetUser(id);
            //if (user != null)
            //{
            //    user.Email = email;
            //    _userRepository.Update(user);
            //}
        }

        public async Task UpdateUserName(Guid id, string name)
        {
            //var user = GetUser(id);
            //if (user != null)
            //{
            //    user.Username = name;
            //    _userRepository.Update(user);
            //}
        }
    }
}
