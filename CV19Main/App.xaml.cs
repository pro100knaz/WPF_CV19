﻿using CV19Main.Services;
using System.IO;
using System.Runtime.CompilerServices;
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

        public static IHost _Host;

        public static IHost Host => _Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

		public static bool IsDesignMode { get; private set; } = true;

		protected override async void OnStartup(StartupEventArgs e)
		{
			IsDesignMode = false;
            var host = Host;
			base.OnStartup(e);

           await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {

            base.OnExit(e);
           var host = Host;

          await host.StopAsync().ConfigureAwait(false);
          
          host.Dispose();
          _Host = null;
        }

        public static void ConfigureServices(HostBuilderContext host,
            IServiceCollection services)
        {
            services
                .RegisterServices()
                .RegisterViewModels();
        }


        public static string CurrentDirectory => IsDesignMode 
            ? Path.GetDirectoryName(GetSourceCodePath())
            : Environment.CurrentDirectory;


        private static string GetSourceCodePath([CallerFilePath]string Path = null) => Path;

    }
	
}
