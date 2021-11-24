using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicAuthenticationSystem.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(GetUsers());

            base.OnModelCreating(modelBuilder);
        }

        private List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "userOne",
                    Password = "myPassword",
                    IV = ""
                },

                new User
                {
                    Id = 2,
                    Username = "userTwo",
                    Password = "myOtherPassword",
                    IV = ""
                }
            };
        }
    }
}
