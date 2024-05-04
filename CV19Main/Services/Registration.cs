using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Services.Interfaces;
using CV19Main.Services.Students;
using Microsoft.Extensions.DependencyInjection;

namespace CV19Main.Services
{
    internal static  class Registration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            //  services.AddScoped<IDataService, DataService>();
            services.AddTransient<IWebServiceServer, HttpListenerWebServer>();
            services.AddTransient<IAsyncDataService, AsyncDataService>();


            services.AddSingleton<StudentsRepository>();
            services.AddSingleton<GroupRepository>();
            services.AddSingleton<StudentsManager>();

            services.AddTransient<IUserDialogService, WindowsUserDialogService>();
            

            return services;
        }

    }
}
