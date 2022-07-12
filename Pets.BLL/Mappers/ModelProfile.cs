using AutoMapper;
using Pets.BLL.Models;
using Pets.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.BLL.Mappers
{
    public class ModelProfile: Profile
    {
        public ModelProfile()
        {
            CreateMap<Pet, PetEntity>().ReverseMap();
        }
    }
}
