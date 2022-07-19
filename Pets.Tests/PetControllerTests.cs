using AutoMapper;
using Moq;
using Pets.API.Controllers;
using Pets.API.ViewModel;
using Pets.BLL.Interfaces;
using Pets.BLL.Models;
using Pets.BLL.Services;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;
using Shouldly;
using System.Collections.Generic;

namespace Pets.Tests
{
    public class PetControllerTests
    {
        [Fact]
        public void GetByIdTest()
        {
            var mock = new Mock<IGenericRepository<PetEntity>>();
            mock.Setup(repo => repo.GetById(1)).Returns(GetTestPetById(1));
            var configModelEntity = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetEntity>().ReverseMap());
            var mapperModelEntity = new Mapper(configModelEntity);
            GenericService<Pet, PetEntity> service = new GenericService<Pet, PetEntity>(mock.Object, mapperModelEntity);
            var configModelVM = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetViewModel>().ReverseMap());
            var mapperModelVM = new Mapper(configModelVM);
            PetController controller = new PetController(service, mapperModelVM);

            var result = controller.GetById(1);

            result.Name.ShouldBe("Tom");
        }

        private PetEntity GetTestPetById(int id)
        {
            var pets = new List<PetEntity>()
            {
                new PetEntity { Id = 1, Name = "Tom", Age = 37, Weight = 10 },
                new PetEntity { Id = 2, Name = "Bob", Age = 41, Weight = 10 },
                new PetEntity { Id = 3, Name = "Sam", Age = 24, Weight = 11 }
            };
            return pets.FirstOrDefault(x => x.Id == id);
        }
    }
}