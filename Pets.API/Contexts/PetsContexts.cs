using Microsoft.EntityFrameworkCore;
using Pets.API.Entities;

namespace Pets.API.Contexts
{
    public class PetsContexts : DbContext
    {
        public DbSet<Pet> Pets { get; set; }


    }
}
