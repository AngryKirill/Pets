using Microsoft.EntityFrameworkCore;
using Pets.DAL.Contexts;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.DAL.Repositories
{
    public class PetRepository: IPetRepository<Pet>
    {
        private readonly PetsContext _context;

        public PetRepository(PetsContext context)
        {
            _context = context;
        }

        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets;
        }

        public Pet GetById(int id)
        {
            return _context.Pets.Find(id);
        }

        public void Create(Pet pet)
        {
            _context.Pets.Add(pet);
        }

        public void Update(Pet pet)
        {
            _context.Entry(pet).State = EntityState.Modified;
        }

        public IEnumerable<Pet> Find(Func<Pet, Boolean> predicate)
        {
            return _context.Pets.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Pet pet = _context.Pets.Find(id);
            if (pet != null)
                _context.Pets.Remove(pet);
        }
    }
}
