using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.BLL.Interfaces;
using Pets.API.ViewModel;
using Pets.BLL.Models;

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _service;

        private readonly IMapper _mapper;

        public PetController(IPetService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PetViewModel> GetAll()
        {
            var allPets = _service.GetAll();
            return _mapper.Map<IEnumerable<Pet>, IEnumerable<PetViewModel>>(allPets);
        }

        [HttpGet("{id}")]
        public PetViewModel GetById(int id)
        {
            var pet = _service.GetById(id);
            return _mapper.Map<Pet, PetViewModel>(pet);
        }

        [HttpPost]
        public void Create(PetViewModel item)
        {
            var pet = _mapper.Map<PetViewModel, Pet>(item);
            _service.Create(pet);
        }

        [HttpPut]
        public void Update(PetViewModel item)
        {
            var pet = _mapper.Map<PetViewModel, Pet>(item);
            _service.Update(pet);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

    }
}
