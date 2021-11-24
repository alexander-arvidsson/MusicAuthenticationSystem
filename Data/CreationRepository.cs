using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAuthenticationSystem.Data
{
    public class CreationRepository
    {
        DatabaseContext context;
        IHash hash;
        public CreationRepository(DatabaseContext context, IHash hash)
        {
            this.context = context;
            this.hash = hash;
        }

        public void CreateUserAsync(User user)
        {
            byte[] iv = hash.GenerateIV();
            user.Password = hash.Encryption(user.Password, iv);
            user.IV = Convert.ToBase64String(iv);

            context.Users.Add(user);
            context.SaveChangesAsync();
        }
    }
}