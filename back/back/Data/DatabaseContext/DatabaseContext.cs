using Back_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Data.DatabaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Application>().ToTable("Applications");

            base.OnModelCreating(modelBuilder);
        }
    }
}
