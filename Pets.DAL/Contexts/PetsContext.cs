using Microsoft.EntityFrameworkCore;
using Pets.DAL.Entities;

namespace Pets.DAL.Contexts
{
    public class PetsContext : DbContext
    {
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<FoodEntity> Foods { get; set; }

        public PetsContext(DbContextOptions<PetsContext> options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>().HasData(
                    new PetEntity { Id = 1, Name = "Tom", Age = 37, Weight = 10 },
                    new PetEntity { Id = 2, Name = "Bob", Age = 41, Weight = 10 },
                    new PetEntity { Id = 3, Name = "Sam", Age = 24, Weight = 11 }
            );
            modelBuilder.Entity<FoodEntity>().HasData(
                    new FoodEntity { Id = 1, Calories = 10, Description = "For fat", Name = "Food1", ProducingCountry = "USA" }
            );
        }
    }
}
