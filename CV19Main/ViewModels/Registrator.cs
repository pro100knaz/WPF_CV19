using Microsoft.Extensions.DependencyInjection;

namespace CV19Main.ViewModels
{
    internal static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<CountryStatisticViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            return services;
        }

    }
}
