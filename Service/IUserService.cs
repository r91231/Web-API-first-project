using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        User GetUser(LogInUser logInUser);
        Task UpdateUser(int id, User updateUserDetails);

    }
}
