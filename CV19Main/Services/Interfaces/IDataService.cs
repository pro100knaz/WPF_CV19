using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CV19Main.Models;

namespace CV19Main.Services.Interfaces
{
    internal interface IDataService
    {
        IEnumerable<CountryInfo> GetData();

    }
}
