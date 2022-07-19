using AutoMapper;
using Pets.API.ViewModel;
using Pets.BLL.Models;
using Pets.DAL.Entities;

namespace Pets.Tests
{
    public static class TestMapper
    {
        public static Mapper GetPetEntityModelMap()
        {
            var configModelEntity = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetEntity>().ReverseMap());
            return new Mapper(configModelEntity);
        }

        public static Mapper GetPetModelVMMap()
        {
            var configModelVM = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetViewModel>().ReverseMap());
            return new Mapper(configModelVM);
        }
    }
}
