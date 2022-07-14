using AutoMapper;
using Pets.BLL.Interfaces;
using Pets.BLL.Models;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;

namespace Pets.BLL.Services
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _repository;

        private readonly IMapper _mapper;

        public PetService(IPetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Pet> GetAll()
        {
            return _mapper.Map<IEnumerable<PetEntity>, IEnumerable<Pet>>(_repository.GetAll());
        }

        public Pet GetById(int id)
        {
            PetEntity pet = _repository.GetById(id);

            if(pet == null)
                throw new ArgumentNullException("Object doesn't exist");
            else
                return _mapper.Map<PetEntity, Pet>(pet);
        }

        public IEnumerable<Pet> Find(Func<Pet, bool> predicate)
        {
            var newPredicate = _mapper.Map<Func<Pet, bool>, Func<PetEntity, bool>>(predicate);
            return _mapper.Map<IEnumerable<PetEntity>, IEnumerable<Pet>>(_repository.Find(newPredicate));
        }

        public void Create(Pet item)
        {
            _repository.Create(_mapper.Map<Pet, PetEntity>(item));
        }

        public void Update(Pet item)
        {
            _repository.Update(_mapper.Map<Pet, PetEntity>(item));
        }

        public void Delete(int id)
        {
            PetEntity pet = _repository.GetById(id);

            if(pet == null)
                throw new ArgumentNullException("Object doesn't exist");
            else
                _repository.Delete(id);
        }
    }   
}
