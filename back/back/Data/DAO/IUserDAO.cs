using Back_End.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_End.DAO
{
    public interface IUserDAO
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
    }
}
