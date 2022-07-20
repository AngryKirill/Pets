using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.BLL.Interfaces;

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TViewModel, TModel>: ControllerBase
        where TViewModel : class
        where TModel : class
    {
        private readonly IGenericService<TModel> _service;

        private readonly IMapper _mapper;

        public GenericController(IGenericService<TModel> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TViewModel>> GetAll()
        {
            var allItems = await _service.GetAll();
            return _mapper.Map<IEnumerable<TModel>, IEnumerable<TViewModel>>(allItems);
        }

        [HttpGet("{id}")]
        public async Task<TViewModel> GetById(int id)
        {
            var pet = await _service.GetById(id);
            return _mapper.Map<TModel, TViewModel>(pet);
        }

        [HttpPost]
        public async Task Create(TViewModel item)
        {
            var newItem = _mapper.Map<TViewModel, TModel>(item);
            await _service.Create(newItem);
        }

        [HttpPut]
        public async Task Update(TViewModel item)
        {
            var updateItem = _mapper.Map<TViewModel, TModel>(item);
            await _service.Update(updateItem);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
