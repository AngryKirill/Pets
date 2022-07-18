using AutoMapper;
using Pets.BLL.Models;
using Pets.DAL.Entities;

namespace Pets.BLL.Mappers
{
    public class ModelProfile: Profile
    {
        public ModelProfile()
        {
            CreateMap<Pet, PetEntity>().ReverseMap();
            CreateMap<Food, FoodEntity>().ReverseMap();
        }
    }
}
