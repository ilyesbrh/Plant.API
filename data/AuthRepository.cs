using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Plant.API.models;

namespace Plant.API.data {
    public class AuthRepository : IAuthRepository {
        private readonly DataContext context;
        public AuthRepository (DataContext context) {
            this.context = context;
        }
        public Task<user> Login (string userName, string password) {
            
            var user = this.context.Users.FirstOrDefault(x => x.userName == userName);
        }
        public async Task<user> Register (user user, string password) {
            
            byte[] hash, salt;
            CreatePasswordHash (password, out hash, out salt);
            user.Salt=salt;
            user.Hash=hash;

            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash (string password, out byte[] hash, out byte[] salt) {
            using (HMACSHA512 Hmac = new HMACSHA512 ())
            {
                salt = Hmac.Key;
                hash = Hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public Task<user> UserExists (string userName) {
            throw new System.NotImplementedException ();
        }
    }
}