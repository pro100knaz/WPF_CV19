using CV19Main.Services;
using System.Configuration;
using System.Data;
using System.Windows;
using CV19Main.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CV19Main
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		


		public static bool IsDesignMode
		{
			get;
			private set;
		} = true;

		protected override void OnStartup(StartupEventArgs e)
		{
			IsDesignMode = false;
			base.OnStartup(e);
		}

        public static void ConfigureServices(HostBuilderContext host,
            IServiceCollection services)
        {
            services.AddSingleton<DataService>();
			services.AddSingleton<CountryStatisticViewModel>();
        }


    }
	
}
