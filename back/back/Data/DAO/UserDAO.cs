using Back_End.Data.DatabaseContext;
using Back_End.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_End.DAO
{
    public class UserDAO : IUserDAO
    {
        private readonly DatabaseContext _context;

        public UserDAO(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
