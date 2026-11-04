using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUser(LogInUser logInUser);
        void UpdateUser(int id, User updateUserDetails);

    }
}
