using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pets.API.Contexts;
using Pets.API.Entities;

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
        public async Task<ActionResult<IEnumerable<Pet>>> GetAll()
        {
            return Ok(await _context.Pets.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Pet>>> Get(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if(pet == null)
                return NotFound();
            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Pet>>> Post(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return Ok(pet);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Pet>>> Put(Pet request)
        {
            var dbPet = await _context.Pets.FindAsync(request.Id);
            if (dbPet == null)
                return BadRequest("Pet not found");

            dbPet.Age = request.Age;
            dbPet.Weight = request.Weight;
            dbPet.Name = request.Name;

            _context.Entry(dbPet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(dbPet);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Pet>>> Delete(int id)
        {
            var dbPet = await _context.Pets.FindAsync(id);
            if(dbPet == null)
                return BadRequest("Pet not found");

            _context.Pets.Remove(dbPet);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
