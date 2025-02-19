using Boostup.API.Entities;
using Boostup.API.Interfaces.Auth;

namespace Boostup.API.Repositories.Auth
{
    public class UserManagerRepository : IUserManagerRepository
    {
        public Task<User?> GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
