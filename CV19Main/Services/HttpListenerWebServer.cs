using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19.Web;
using CV19Main.Services.Interfaces;

namespace CV19Main.Services
{
    internal class HttpListenerWebServer : IWebServiceServer
    {

        private readonly WebServer _server = new WebServer(8080);

        public bool Enabled { get => _server.Enabled; set => _server.Enabled = value; }
        public void Start() => _server.Start();

        public void Stop() => _server.Stop();

        public HttpListenerWebServer()
        {
            _server.RequestReceiver += OnRequestReceived;
        }

        private static void OnRequestReceived(object? sender, RequestReceiverEventArgs e)
        {
            using var writer = new StreamWriter(e.Context.Response.OutputStream);

            writer.WriteLine("CV-19 Application" + DateTime.Now);

        }
    }
}
