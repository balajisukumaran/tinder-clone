using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tinder.API.Models;

namespace Tinder.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            this._context=context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user=await _context.Users.FirstOrDefaultAsync(x=> x.UserName==username);
            if(user==null)
                return null;
            if(!VerifyPasswordHash(password, user.PasswordHash,user.PasswordSalt))
                return null;
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0;i<computedHash.Length;i++){
                    if(computedHash[i]!=passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passworHash, passwordSalt;
            CreatePasswordHash(password,out passworHash,out passwordSalt);
            user.PasswordHash=passworHash;
            user.PasswordSalt=passwordSalt;

            _context.Users.AddAsync(user);
            _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passworHash, out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512()){
                passwordSalt=hmac.Key;
                passworHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _context.Users.AnyAsync(x=>x.UserName==username))
                return true;
            return false;
        }
    }
}