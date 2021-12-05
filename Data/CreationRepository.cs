using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAuthenticationSystem.Data
{
    public class CreationRepository
    {
        private DatabaseContext context;
        private IHash hash;
        public CreationRepository(DatabaseContext context, IHash hash)
        {
            this.context = context;
            this.hash = hash;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if(context.Users.Any(u => u.Username == user.Username))
            {
                return false;
            } else
            {
                byte[] iv = hash.GenerateIV();
                user.Password = hash.Encryption(user.Password, iv);
                user.IV = Convert.ToBase64String(iv);
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}