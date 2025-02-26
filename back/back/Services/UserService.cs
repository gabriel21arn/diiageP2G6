using Back_End.DAO;
using Back_End.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_End.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDAO;

        public UserService(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userDAO.GetAllUsersAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userDAO.AddUserAsync(user);
        }
    }
}
