using Back_End.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_End.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
