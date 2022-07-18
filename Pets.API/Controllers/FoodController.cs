using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pets.API.ViewModel;
using Pets.BLL.Interfaces;
using Pets.BLL.Models;

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : GenericController<FoodViewModel, Food>
    {
        public FoodController(IGenericService<Food> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
