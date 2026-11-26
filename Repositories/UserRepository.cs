using Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
namespace Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly StoreDBContext _context;
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

        public Task<User> GetUser(LogInUser logInUser)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == logInUser.Email && u.Password == logInUser.Password);
        }

        public async Task UpdateUser(int id, User updateUserDetails)
        {
            updateUserDetails.Id = id;
            _context.Users.Update(updateUserDetails);
            await _context.SaveChangesAsync();
        }
    }
}
