using Pets.DAL.Contexts;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;

namespace Pets.DAL.Repositories
{
    public class FoodRepository: GenericRepository<FoodEntity>, IFoodRepository
    {
        public FoodRepository(PetsContext context) : base(context)
        {

        }
    }
}
