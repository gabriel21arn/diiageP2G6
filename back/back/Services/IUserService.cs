using Back_End.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_End.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
    }
}
