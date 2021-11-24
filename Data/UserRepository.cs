using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAuthenticationSystem.Data
{
    public class UserRepository
    {
        private readonly DatabaseContext context;
        private IHash hash;
        public UserRepository(DatabaseContext context, IHash hash)
        {
            this.context = context;
            this.hash = hash;
        }

        public string GetPassword(User user)
        {
            string password = context.Users.Where(u => u.Username == user.Username).Select(u => u.Password).First().ToString();
            return password;
        }

        public byte[] GetIV(User user)
        {
            string iv = context.Users.Where(u => u.Username == user.Username).Select(u => u.IV).First().ToString();
            return Convert.FromBase64String(iv);
        }

        public bool MatchPassword(User user, string enteredPassword)
        {
            byte[] key = GetIV(user);

            string correctPassword = GetPassword(user);
            byte[] correctPasswordBytes = Convert.FromBase64String(correctPassword);
            
            string decryptedPassword = hash.Decryption(correctPasswordBytes, key);
         
            if (enteredPassword.Equals(decryptedPassword))
                return true;
            
            return false;
        }
    }
}