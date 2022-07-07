using Microsoft.EntityFrameworkCore;
using Pets.API.Entities;

namespace Pets.API.Contexts
{
    public class PetsContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public PetsContext(DbContextOptions<PetsContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasData(
                    new Pet { Id = 1, Name = "Tom", Age = 37, Weight = 10 },
                    new Pet { Id = 2, Name = "Bob", Age = 41, Weight = 10 },
                    new Pet { Id = 3, Name = "Sam", Age = 24, Weight = 11 }
            );
        }
    }
}
