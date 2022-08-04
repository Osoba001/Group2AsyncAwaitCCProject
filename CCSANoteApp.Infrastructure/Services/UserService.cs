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

        public void CreateUser(string username, string email, string password)
        {
            _userRepository.Add(new User
            {
                Email = email,
                Username = username,
                Password = password
            });
        }

        public void CreateUser(User user)
        {
            _userRepository.Add(user);
        }

        public void DeleteUser(Guid id)
        {
            _userRepository.DeleteById(id);
        }

        public UserDto GetUser(Guid id)
        {
            //Refactor to add user notes
            var user = _userRepository.GetById(id);

            var result = new UserDto
            {
                Username = user.Username,
                Email = user.Email
            };
            return result;
        }

        public List<User> GetUsers()
        {
            //Refactor
            return _userRepository.GetAll();
        }

        public void UpdateUserEmail(Guid id, string email)
        {
            //var user = GetUser(id);
            //if (user != null)
            //{
            //    user.Email = email;
            //    _userRepository.Update(user);
            //}
        }

        public void UpdateUserName(Guid id, string name)
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
