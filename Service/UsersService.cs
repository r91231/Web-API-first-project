using Entities;
using Repositories;
using System.Text.Json;     

namespace Services
{
    public class UsersService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }
        public User GetUser(LogInUser logInUser)
        {
            return _userRepository.GetUser(logInUser);
        }
        public void UpdateUser(int id, User updateUserDetails)
        {
            _userRepository.UpdateUser(id, updateUserDetails);
        }

    }
}
