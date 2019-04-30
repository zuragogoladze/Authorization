using Authorization.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Authorization.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "zura1",
                    Password = "9PsbZovEoCkMiksUuLhLWYjwMSpUKLFbKw2u8dO/9Wg=" //Hashed password1
                }
            );
        }
    }
}
