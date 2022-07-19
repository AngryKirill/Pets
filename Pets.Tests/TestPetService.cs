using AutoMapper;
using Pets.BLL.Models;
using Pets.BLL.Services;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;

namespace Pets.Tests
{
    public static class TestPetService
    {
        public static GenericService<Pet, PetEntity> GetPetService(IGenericRepository<PetEntity> repository)
        {
            return new GenericService<Pet, PetEntity>(repository, TestMapper.GetPetEntityModelMap());
        }
    }
}
