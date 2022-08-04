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

        public async Task<IQueryable<User>> GetUser(Guid id)
        {
            //Refactor to add user notes
            var user =  _userRepository.GetById(id);

            
            return user;
        }

        public async Task<IQueryable<User>> GetUsers()
        {
            //Refactor
            return _userRepository.GetAll();
        }

        public async Task<bool> UpdateUserEmail(Guid id, string email)
        {
            //var user = GetUser(id);
            //if (user != null)
            //{
            //    user.Email = email;
            //    _userRepository.Update(user);
            //}
            return true;
        }

        public async Task<bool> UpdateUserName(Guid id, string name)
        {
            //var user = GetUser(id);
            //if (user != null)
            //{
            //    user.Username = name;
            //    _userRepository.Update(user);
            //}
            return true;
        }
        
    }
}
