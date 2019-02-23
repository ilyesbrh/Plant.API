using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plant.API.models;

namespace Plant.API.data {
    public class AuthRepository : IAuthRepository {
        private readonly DataContext context;
        public AuthRepository (DataContext context) {
            this.context = context;
        }
        public async Task<User> Login (string userName, string password) {
            
            var User = await this.context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (!verifyPassword(User,password))
            {
                return null;
            }else
            {
                return User;
            } 
        }

        private bool verifyPassword(User user,string password)
        {
            if(user==null) return false;

            using (HMACSHA512 Hmac = new HMACSHA512 (user.Salt))
            {
                var hash = Hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < user.Hash.Length; i++)
                {
                    if(hash[i]!=user.Hash[i])return false;
                }

                return true;
            }

        }

        public async Task<User> Register (string username, string password) {
            
            byte[] hash, salt;
            CreatePasswordHash (password, out hash, out salt);
            
            User User= new User
            {
                UserName = username,
                Salt=salt,
                Hash=hash
            };
            await this.context.Users.AddAsync(User);
            await this.context.SaveChangesAsync();
            return User;
        }

        private void CreatePasswordHash (string password, out byte[] hash, out byte[] salt) {
            using (HMACSHA512 Hmac = new HMACSHA512 ())
            {
                salt = Hmac.Key;
                hash = Hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        public async Task<bool> UserExists (string userName) {

            return await context.Users.AnyAsync(x => x.UserName == userName);
        }
    }
}