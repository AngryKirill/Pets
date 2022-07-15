using Pets.DAL.Contexts;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;
    
namespace Pets.DAL.Repositories
{
    public class PetRepository : GenericRepository<PetEntity>, IPetRepository
    {
        public PetRepository(PetsContext context) : base(context)
        {

        }
    }
}
