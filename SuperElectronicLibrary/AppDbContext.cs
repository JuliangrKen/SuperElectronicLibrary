using Microsoft.EntityFrameworkCore;
using SuperElectronicLibrary.Models;

namespace SuperElectronicLibrary
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Genre>? Genre { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS01;" +
                                        "Initial Catalog=testing;" +
                                        "Integrated Security=True;" +
                                        "TrustServerCertificate=True");

        }
    }
}
