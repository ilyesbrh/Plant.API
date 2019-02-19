using System.Threading.Tasks;
using Plant.API.models;

namespace Plant.API.data
{
    public interface IAuthRepository
    {
         Task<user> Register(string user ,string password);
         Task<user> Login(string userName ,string password);
         Task<bool> UserExists(string userName);
    }
}