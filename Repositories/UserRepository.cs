using Entities;
using Microsoft.EntityFrameworkCore;
//This using isn't used in this file: you can remove it
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository:IUserRepository
    {
        StoreDBContext _context;
        public UserRepository(StoreDBContext context)
        {
            _context = context;
        }
        public async Task<User> AddUser(User user)
        {
            _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public User GetUser(LogInUser logInUser)
        {
            User user = _context.Users.ToList().Find(u => u.Email==logInUser.Email && u.Password == logInUser.Password);
            return user;
        }

        public async Task UpdateUser(int id, User updateUserDetails)
        {
            _context.Users.Remove(_context.Users.ToList().Find(u=>u.Id==id));
            _context.Users.AddAsync(updateUserDetails);
            await _context.SaveChangesAsync();
        }
    }
}
