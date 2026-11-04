using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        User AddUser(User user);
        User GetUser(LogInUser logInUser);
        void UpdateUser(int id, User updateUserDetails);

    }
}
