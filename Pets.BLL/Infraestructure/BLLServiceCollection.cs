using Microsoft.Extensions.DependencyInjection;
using Pets.BLL.Interfaces;
using Pets.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.BLL.Infraestructure
{
    public static class BLLServiceCollection
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IPetService, PetService>();
            return services;
        }
    }
}
