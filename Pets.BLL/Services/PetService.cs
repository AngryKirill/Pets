using AutoMapper;
using Pets.BLL.Interfaces;
using Pets.BLL.Models;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.BLL.Services
{
    internal class PetService: IPetService
    {
        IPetRepository Repository { get; set; }

        private readonly Mapper _mapper;

        public PetService(IPetRepository repository, Mapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Pet> GetAll()
        {
            return _mapper.Map<IEnumerable<PetEntity>, IEnumerable<Pet>>(Repository.GetAll());
        }

        public Pet GetById(int id)
        {
            return _mapper.Map<PetEntity, Pet>(Repository.GetById(id));
        }

        public IEnumerable<Pet> Find(Func<Pet, bool> predicate)
        {
            var newPredicate = _mapper.Map<Func<Pet, bool>, Func<PetEntity, bool>>(predicate);
            return _mapper.Map<IEnumerable<PetEntity>, IEnumerable<Pet>>(Repository.Find(newPredicate));
        }

        public void Create(Pet item)
        {
            Repository.Create(_mapper.Map<Pet, PetEntity>(item));
        }

        public void Update(Pet item)
        {
            Repository.Update(_mapper.Map<Pet, PetEntity>(item));
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }
    }   
}
