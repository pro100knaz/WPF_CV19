using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CV19Main.Services
{
    internal static  class Registration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            //  services.AddScoped<IDataService, DataService>();

            services.AddTransient<IAsyncDataService, AsyncDataService>();

            return services;
        }

    }
}
