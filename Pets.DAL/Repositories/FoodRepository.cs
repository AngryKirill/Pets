using Microsoft.EntityFrameworkCore;
using Pets.DAL.Contexts;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;

namespace Pets.DAL.Repositories
{
    public class FoodRepository: IFoodRepository
    {
        private readonly PetsContext _context;

        public FoodRepository(PetsContext context)
        {
            _context = context;
        }

        public IEnumerable<FoodEntity> GetAll()
        {
            return _context.Foods;
        }

        public FoodEntity GetById(int id)
        {
            return _context.Foods.Find(id);
        }

        public void Create(FoodEntity food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public void Update(FoodEntity pet)
        {
            _context.Entry(pet).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<FoodEntity> Find(Func<FoodEntity, Boolean> predicate)
        {
            return _context.Foods.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            FoodEntity food = _context.Foods.Find(id);
            _context.Foods.Remove(food);
            _context.SaveChanges();
        }
    }
}
