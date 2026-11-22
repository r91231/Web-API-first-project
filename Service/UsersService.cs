using Entities;
using Repositories;
//This using isn't used in this file: you can remove it
using System.Runtime.CompilerServices;
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
        public User GetUser(LogInUser logInUser)
        {
            return _userRepository.GetUser(logInUser);
        }
        public async Task UpdateUser(int id, User updateUserDetails)
        {
            await _userRepository.UpdateUser(id, updateUserDetails);
        }

    }
}
