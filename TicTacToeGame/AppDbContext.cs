using Microsoft.EntityFrameworkCore;
using TicTacToeGame.Classes;
using TicTacToeGame.Model;

namespace TicTacToeGame
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@example.com",
                    Password = HashPassword.Hash("password123"),
                    NumWins = 0
                }
            );
        }
    }
}
