using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19Main
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseContentRoot(App.CurrentDirectory)
                .ConfigureAppConfiguration((host, cfg) => cfg
                    .SetBasePath(App.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
                .ConfigureServices(App.ConfigureServices);

        //public static IHostBuilder CreateHostBuilder(string[] args)
        //{
        //    var host_builder = Host.CreateDefaultBuilder(args);

        //    host_builder.UseContentRoot(App.CurrentDirectory);
        //    host_builder.ConfigureAppConfiguration((host, cfg) =>
        //    {
        //        cfg.SetBasePath(App.CurrentDirectory);
        //        cfg.AddJsonFile("appsettings.json", optional: true,
        //            reloadOnChange: true);
        //    });

        //    host_builder.ConfigureServices(App.ConfigureServices);

        //    return host_builder;
        //}
    }
}
