using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pets.BLL.Interfaces;
using Pets.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BLLServiceCollection
    {
        public static void AddBLLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPetService, PetService>();
            services.AddDALServices(configuration);
        }
    }
}
