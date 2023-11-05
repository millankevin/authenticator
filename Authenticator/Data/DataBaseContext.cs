using Authenticator.Configurations;
using Authenticator.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Authenticator.Data
{
    public class DataBaseContext : DbContext
    {
   

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UsersConfiguration());
            //modelBuilder.ApplyConfiguration();

        }
    }
}
