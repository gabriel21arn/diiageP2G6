using Back_End.Models;
using Back_End.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IUserDAO _userDAO;

        public PasswordService(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public async Task<IEnumerable<string>> GetAllPasswordAsync()
        {
            var users = await _userDAO.GetAllUsersAsync();

            var passwords = users.Select(user => user.MotDePasse);

            return passwords;
        }
    }
}
