using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19.Web;

namespace CV19Console
{
    internal static class WebServerTest
    {
        public static void Run()
        {

            var server = new WebServer(8080);
            server.RequestReceiver += OnRequestReceiver;

            server.Start();

            Console.WriteLine("сервер запущен");


            Console.ReadLine();
        }

        private static void OnRequestReceiver(object? sender, RequestReceiverEventArgs e)
        {
            var context = e.Context;

            Console.WriteLine("Connection {0}", context.Request.UserHostAddress);

            using var writer = new StreamWriter(context.Response.OutputStream);
            writer.WriteLine("Hello from Test Web Server !!!");
        }
    }
}
