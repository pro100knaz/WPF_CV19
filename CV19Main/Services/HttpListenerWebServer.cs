using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Services.Interfaces;

namespace CV19Main.Services
{
    internal class HttpListenerWebServer : IWebServiceServer
    {
        public bool Enabled { get; set; }
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
