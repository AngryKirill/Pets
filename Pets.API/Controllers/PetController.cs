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
        IPetService Service { get; set; }

        private readonly Mapper _mapper;

        public PetController(IPetService service, Mapper mapper)
        {
            Service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PetViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<Pet>, IEnumerable<PetViewModel>>(Service.GetAll());
        }

        [HttpGet("{id}")]
        public PetViewModel GetById(int id)
        {
            return _mapper.Map<Pet, PetViewModel>(Service.GetById(id));
        }

        [HttpPost]
        public void Create(PetViewModel item)
        {
            Service.Create(_mapper.Map<PetViewModel, Pet>(item));
        }

        [HttpPut]
        public void Update(PetViewModel item)
        {
            Service.Update(_mapper.Map<PetViewModel, Pet>(item));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Service.Delete(id);
        }

    }
}
