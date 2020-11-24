using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace FortCode.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(){ }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("ConnectionStrings: DbContext");
        }

        public DbSet<User> User { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}
