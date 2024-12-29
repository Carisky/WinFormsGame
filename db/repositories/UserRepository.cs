using Microsoft.EntityFrameworkCore;
using WinFormsGame.db.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinFormsGame.db.repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Create or Update User
        public async Task AddOrUpdateUserAsync(User user)
        {
            if (_context.Users.Any(u => u.Id == user.Id))
            {
                _context.Users.Update(user);
            }
            else
            {
                await _context.Users.AddAsync(user);
            }
            await _context.SaveChangesAsync();
        }

        // Get all Users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Get User by Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Get User by Username
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        // Delete User by Id
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
