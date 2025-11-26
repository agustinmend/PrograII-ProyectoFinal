using System;
using System.Threading.Tasks;
namespace Backend.Data
{
    public interface IUserRepository
    {
        Task CreateUserAsync(UserBD user);
        Task<UserBD?> GetByEmailAsync(string email);
        Task<UserBD?> GetByUsernameAsync(string username);
        Task<UserBD?> GetByIdAsync(string Id);
    }
}

