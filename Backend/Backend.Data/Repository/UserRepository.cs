using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace Backend.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserBD> _users;
        public UserRepository(MongoDBContext context)
        {
            _users = context.Users;
        }
        public async Task CreateUserAsync(UserBD user)
        {
            await _users.InsertOneAsync(user);
        }
        public async Task<UserBD?> GetByEmailAsync(string email)
        {
            return await _users.Find(x => x.Email == email).FirstOrDefaultAsync();
        }
        public async Task<UserBD?> GetByUsernameAsync(string username)
        {
            return await _users.Find(x => x.Username == username).FirstOrDefaultAsync();
        }
        public async Task<UserBD?> GetByIdAsync(string id)
        {
            return await _users.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}

