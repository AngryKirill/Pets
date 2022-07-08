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

        public PetService(IPetRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Pet> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PetEntity, Pet>()).CreateMapper();
            return mapper.Map<IEnumerable<PetEntity>, IEnumerable<Pet>>(Repository.GetAll());
        }

        public Pet GetById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PetEntity, Pet>()).CreateMapper();
            return mapper.Map<PetEntity, Pet>(Repository.GetById(id));
        }

        public IEnumerable<Pet> Find(Func<Pet, bool> predicate)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PetEntity, Pet>()).CreateMapper();
            var newPredicate = mapper.Map<Func<Pet, bool>, Func<PetEntity, bool>>(predicate);
            return mapper.Map<IEnumerable<PetEntity>, IEnumerable<Pet>>(Repository.Find(newPredicate));
        }

        public void Create(Pet item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PetEntity, Pet>()).CreateMapper();
            Repository.Create(mapper.Map<Pet, PetEntity>(item));
        }

        public void Update(Pet item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PetEntity, Pet>()).CreateMapper();
            Repository.Update(mapper.Map<Pet, PetEntity>(item));
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }
    }   
}
