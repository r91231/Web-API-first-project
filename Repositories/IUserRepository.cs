using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        User GetUser(LogInUser logInUser);
        Task UpdateUser(int id, User updateUserDetails);

    }
}
