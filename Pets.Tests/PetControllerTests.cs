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
            //Arrange
            var mock = new Mock<IGenericRepository<PetEntity>>();
            mock.Setup(repo => repo.GetById(1)).Returns(GetTestPetById(1));
            PetController controller = new PetController(TestPetService.GetPetService(mock.Object),
                TestMapper.GetPetModelVMMap());

            //Act
            var result = controller.GetById(1);

            //Assert
            result.Name.ShouldBe("Tom");
        }

        private static PetEntity GetTestPetById(int id)
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