using AutoMapper;
using Moq;
using Pets.API.Controllers;
using Pets.API.ViewModel;
using Pets.BLL.Models;
using Pets.BLL.Services;
using Pets.DAL.Entities;
using Pets.DAL.Interfaces;
using Shouldly;

namespace Pets.Tests
{
    public class PetServiceTests
    {
        [Fact]
        public async Task GetPetById_ValidId_ReturnsPet()
        {
            //Arrange
            Pet model = TestPetData.GetPetModel();
            var mockMapper = new Mock<IMapper>();
            var mockRepo = new Mock<IGenericRepository<PetEntity>>();

            mockMapper.Setup(mapper => mapper.Map<PetEntity, Pet>(It.IsAny<PetEntity>())).Returns(model);
            mockRepo.Setup(repo => repo.GetById(model.Id)).Returns(TestPetData.GetTaskPetEntity());

            GenericService<Pet, PetEntity> service = new GenericService<Pet, PetEntity>(mockRepo.Object, mockMapper.Object);

            //Act
            var result = await service.GetById(1);

            //Assert
            result.ShouldBeEquivalentTo(model);
        }
    }
}