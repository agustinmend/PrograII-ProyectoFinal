using System;
using System.Threading.Tasks;
using Backend.Data;
namespace Backend.Business
{
    public interface IUserService
    {
        public Task RegisterUserAsync(CreateUserDto userDto);
        public Task<UserProfileDto> GetUserProfileAsync(string userId);
        public Task<string> LoginAsync(string username, string password);
    }
}
