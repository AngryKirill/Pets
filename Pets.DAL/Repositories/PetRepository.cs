using Microsoft.EntityFrameworkCore;
using Pets.DAL.Contexts;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;

namespace Pets.DAL.Repositories
{
    public class PetRepository: IPetRepository
    {
        private readonly PetsContext _context;

        public PetRepository(PetsContext context)
        {
            _context = context;
        }

        public IEnumerable<PetEntity> GetAll()
        {
            return _context.Pets;
        }

        public PetEntity GetById(int id)
        {
            return _context.Pets.Find(id);
        }

        public void Create(PetEntity pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public void Update(PetEntity pet)
        {
            _context.Entry(pet).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<PetEntity> Find(Func<PetEntity, Boolean> predicate)
        {
            return _context.Pets.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            PetEntity pet = _context.Pets.Find(id);
            if (pet != null)
                _context.Pets.Remove(pet);
            _context.SaveChanges();
        }
    }
}
