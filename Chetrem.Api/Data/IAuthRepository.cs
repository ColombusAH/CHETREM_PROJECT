using System.Threading.Tasks;
using Chetrem.Api.Models;

namespace Chetrem.Api.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExist(string username);
    }
}