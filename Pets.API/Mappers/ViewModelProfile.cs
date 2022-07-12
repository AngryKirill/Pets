using AutoMapper;
using Pets.API.ViewModel;
using Pets.BLL.Models;

namespace Pets.API.Mappers
{
    public class ViewModelProfile: Profile
    {
        public ViewModelProfile()
        {
            CreateMap<PetViewModel, Pet>().ReverseMap();
        }
    }
}
