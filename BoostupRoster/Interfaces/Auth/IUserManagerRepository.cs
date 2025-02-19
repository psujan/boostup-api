using Boostup.API.Entities;

namespace Boostup.API.Interfaces.Auth
{
    public interface IUserManagerRepository
    {
        Task<User?> GetUserByUserName(string userName);
    }
}
