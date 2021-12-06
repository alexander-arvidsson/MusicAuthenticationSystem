using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicAuthenticationSystem.Data
{
    public class CreationRepository
    {
        private DatabaseContext context;
        private IHash hash;
        private StreamWriter SW;
        public CreationRepository(DatabaseContext context, IHash hash)
        {
            this.context = context;
            this.hash = hash;
        }

        public async Task<bool> CreateUserAsync(User user, string pass)
        {
            if(context.Users.Any(u => u.Username == user.Username))
            {
                return false;
            } else
            {
                SW = new StreamWriter(".//MelokeyLength.txt", true);
                await SW.WriteLineAsync(GetLength(pass));
                SW.Close();

                byte[] iv = hash.GenerateIV();
                user.Password = hash.Encryption(user.Password, iv);
                user.IV = Convert.ToBase64String(iv);
                context.Users.Add(user);

                await context.SaveChangesAsync();
                return true;
            }
        }

        private string GetLength(string pass)
        {
            string mk = Regex.Replace(pass, @"[\d]*s*", "");
            return mk.Length.ToString();
        }
    }
}