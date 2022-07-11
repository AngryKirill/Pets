using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        private readonly Mapper _mapper;

        public PetController(IPetService service, Mapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PetViewModel> GetAll()
        {
            return _mapper
                .Map<IEnumerable<Pet>, IEnumerable<PetViewModel>>(_service
                .GetAll());
        }

        [HttpGet("{id}")]
        public PetViewModel GetById(int id)
        {
            return _mapper.Map<Pet, PetViewModel>(_service.GetById(id));
        }

        [HttpPost]
        public void Create(PetViewModel item)
        {
            _service.Create(_mapper.Map<PetViewModel, Pet>(item));
        }

        [HttpPut]
        public void Update(PetViewModel item)
        {
            _service.Update(_mapper.Map<PetViewModel, Pet>(item));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

    }
}
