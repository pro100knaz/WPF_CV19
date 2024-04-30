using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Services.Interfaces;

namespace CV19Main.Services
{
    internal class AsyncDataService : IAsyncDataService
    {
        private const int _SleeepTime = 7000;
        public string GetResult(DateTime Time)
        {
            Thread.Sleep(_SleeepTime);

            return $"result value = {Time}";
        }
    }
}
