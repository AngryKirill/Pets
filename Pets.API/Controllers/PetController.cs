using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pets.DAL.Contexts;
using Pets.DAL.Entities;

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetsContext _context;

        public PetController(PetsContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets.ToList();
        }

        [HttpGet("{id}")]
        public Pet GetById(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null)
                throw new ArgumentNullException("Object cannot be null", nameof(pet));
            return pet;
        }

        [HttpPost]
        public void Add(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Update(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dbPet = _context.Pets.Find(id);
            if(dbPet == null)
                throw new ArgumentNullException("Object cannot be null", nameof(dbPet));

            _context.Pets.Remove(dbPet);
            _context.SaveChanges();
        }

    }
}
