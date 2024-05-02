using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19Main.Services.Interfaces
{
    internal interface IWebServiceServer
    {
        bool Enabled { get; set; }
        void Start();

        void Stop();

    }
}
