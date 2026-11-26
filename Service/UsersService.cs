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
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }
        public async Task<User> GetUser(LogInUser logInUser)
        {
            return await _userRepository.GetUser(logInUser);
        }
        public async Task UpdateUser(int id, User updateUserDetails)
        {
            await _userRepository.UpdateUser(id, updateUserDetails);
        }

    }
}
