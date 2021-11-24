using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAuthenticationSystem.Data
{
    public class AuthenticationRepository
    {
        private readonly DatabaseContext context;

        public AuthenticationRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}