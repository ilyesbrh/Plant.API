using System.Threading.Tasks;
using Plant.API.models;

namespace Plant.API.data
{
    public interface IAuthRepository
    {
         Task<User> Register(string user ,string password);
         Task<User> Login(string userName ,string password);
         Task<bool> UserExists(string userName);
    }
}