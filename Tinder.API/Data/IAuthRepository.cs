using System.Threading.Tasks;
using Tinder.API.Models;

namespace Tinder.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user,string password);

         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
         
    }
}